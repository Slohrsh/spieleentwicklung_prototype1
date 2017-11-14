using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform Player;
    public int speed;
    public int life;
    public int MinDist;
    public float bounceBackForce;

    private Rigidbody enemyRigidbody;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        { 
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(life <= 0)
        {
            enemyRigidbody.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            Debug.Log(life);
            life -= 1;
            other.gameObject.SetActive(false);
        }
    }
}
