using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameManager gameManager;
    public GameObject projectilePrefab;
 

    public int jumpPower;

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
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 lookhere = new Vector3(0, moveHorizontal, 0);
        transform.Rotate(lookhere);

        currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = speed * 1.5f;
        }

        playerRigidbody.AddForce(transform.forward * moveVertical* currentSpeed);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            shoot();
        }

        if (Input.GetKey(KeyCode.Space) && (!isJumping || isJetpack))
        {
            playerRigidbody.AddForce(Vector3.up * jumpPower);
            isJumping = true;
        }
        checkFallOutOfMap();
        givePowerupEffects();
    }

    void givePowerupEffects()
    {
        float timerMax;

        if (isJetpack == true)
        {
            timerMax = 5;

            powerupTimer += Time.deltaTime;

            if (powerupTimer >= timerMax)
            {
                Debug.Log("timerMax reached !");
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goal");
            playerRigidbody.AddForce(Vector3.up * 500);
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
