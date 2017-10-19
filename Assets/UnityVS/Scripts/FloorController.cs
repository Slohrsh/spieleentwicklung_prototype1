using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

    public float min = 2f;
    public float max = 3f;

    public bool isMovable;

    private Rigidbody floorRigidbod;

    void Start()
    {
        floorRigidbod = GetComponent<Rigidbody>();
        min = floorRigidbod.position.x - 3;
        max = floorRigidbod.position.x + 3;
    }
        
    void FixedUpdate ()
    {
        if (isMovable)
        {
            floorRigidbod.MovePosition(new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, floorRigidbod.position.y, floorRigidbod.position.z));
        }
        
    }

  
}