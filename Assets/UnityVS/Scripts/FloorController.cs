using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

    public float min = 2f;
    public float max = 3f;

    public bool isMovingLeftAndRigth;
    public bool isMovingUpAndDown;
    public bool isMovingBackAndForth;

    private Rigidbody floorRigidbod;

    void Start()
    {
        floorRigidbod = GetComponent<Rigidbody>();
    }
        
    void FixedUpdate ()
    {
        if (isMovingBackAndForth)
        {
            floorRigidbod.MovePosition(new Vector3(floorRigidbod.position.x, floorRigidbod.position.y, Mathf.PingPong(Time.time * 2, max - min) + min));
        }
        if (isMovingUpAndDown)
        {
            floorRigidbod.MovePosition(new Vector3(floorRigidbod.position.x, Mathf.PingPong(Time.time * 2, max - min) + min, floorRigidbod.position.z));
        }
        if (isMovingLeftAndRigth)
        {
            floorRigidbod.MovePosition(new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, floorRigidbod.position.y, floorRigidbod.position.z));
        }

    }

  
}