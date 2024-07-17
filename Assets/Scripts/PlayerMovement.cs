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
    

    void Start()
    {
     forwardForce = 0;
     xRotationSpeed = 0;
     yRotationSpeed = 0;
     JumpForce = 0;
     rigidbody = GetComponent<Rigidbody>();
     xRotation = 0;
     yRotation = 0;

    }
private Rigidbody rigidbody;
private float xRotation;
private float yRotation;

    void Update()
    {
     Vector3 forwardDirection = Orientation.transform.forward;
     rigidbody.AddForce(forwardDirection.normalized*forwardForce);
     xRotation += xRotationSpeed;
     yRotation += yRotationSpeed;
     Orientation.transform.rotation = Quaternion.Euler(0,yRotation,0);
     LookDirection.transform.rotation = Quaternion.Euler(xRotation,yRotation,0);

    }
}
