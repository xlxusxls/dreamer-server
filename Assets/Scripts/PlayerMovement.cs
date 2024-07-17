using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Orientation;
    public GameObject LookDirection;

    //힘에 대한 정보
 
    public float forwardForce;
    public float xRotationSpeed;
    public float yRotationSpeed;
    public float JumpForce;

    private Rigidbody rb;
    private float xRotation;
    private float yRotation;


    void Start()
    {
     forwardForce = 0;
     xRotationSpeed = 0;
     yRotationSpeed = 0;
     JumpForce = 0;
     rb = GetComponent<Rigidbody>();
     xRotation = 0;
     yRotation = 0;

    }


    void Update()
    {
     Vector3 forwardDirection = Orientation.transform.forward;
     rb.AddForce(forwardDirection.normalized*forwardForce*2);
     xRotation += xRotationSpeed;
     yRotation += yRotationSpeed;
     Orientation.transform.rotation = Quaternion.Euler(0,yRotation,0);
     LookDirection.transform.rotation = Quaternion.Euler(xRotation,yRotation,0);

    }
}
