using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform Player;
    public int speed;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Player);

        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
