using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameManager gameManager;
    public GameObject projectilePrefab;
    public List<GameObject> portals;
 

    public int jumpPower;
    public int JetpackPower;

    private Rigidbody playerRigidbody;
    private bool isJumping = false;
    
    private float currentSpeed;
    private bool isJetpack = false;

    private float powerupTimer;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        handleInputs();
        checkFallOutOfMap();
        handleTimer();
    }

    private void handleInputs()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 lookhere = new Vector3(0, moveHorizontal*5, 0);
        transform.Rotate(lookhere);

        currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = speed * 1.5f;
        }

        playerRigidbody.AddForce(transform.forward * moveVertical * currentSpeed);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            shoot();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isJetpack)
            {
                playerRigidbody.AddForce(Vector3.up * JetpackPower);
            }else if(!isJumping)
            {
                playerRigidbody.AddForce(Vector3.up * jumpPower);
                isJumping = true;
            }
        }
    }

    void handleTimer()
    {
        handleJetPackTimer();
    }

    private void handleJetPackTimer()
    {
        float timerMax;

        if (isJetpack == true)
        {
            timerMax = 5;
            powerupTimer += Time.deltaTime;
            if (powerupTimer >= timerMax)
            {
                isJetpack = false;
            }
        }
    }

    void checkFallOutOfMap()
    {
        if(transform.position.y < 0)
        {
            gameManager.resetGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            gameManager.resetGame();
        }
        if (other.gameObject.CompareTag("JetPack"))
        {
            isJetpack = true;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Portal"))
        {
            foreach (GameObject portal in portals)
            {
                if (!GameObject.ReferenceEquals(other.gameObject, portal))
                {
                    transform.position = portal.transform.position;
                }
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            isJumping = false;
            Debug.Log("Goal");
            gameManager.gameWon();
        }


    }

    private void shoot()
    {
        GameObject projectile;
        Rigidbody projectileRigidBody;
        projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.SetActive(true);
        projectileRigidBody = projectile.GetComponent<Rigidbody>();
        projectileRigidBody.AddForce(transform.forward * 150000.0f* Time.deltaTime);
    }

}
