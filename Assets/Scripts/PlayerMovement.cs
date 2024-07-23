using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Orientation;
    public GameObject LookDirection;

    //힘에 대한 정보
 
    public float forwardForce;
    public float horizontalForce;
    public float horizontalMoveCoefficient = 10f;
    public float forwardMoveCoefficient = 10f;
    public float xRotationSpeed;
    public float yRotationSpeed;
    public float JumpForce;

    private Rigidbody rb;
    private float xRotation;
    private float yRotation;

    public float rho = 0.2f;


    void Start()
    {
        forwardForce = 0;
        horizontalForce = 0;
        xRotationSpeed = 0;
        yRotationSpeed = 0;
        JumpForce = 0;
        rb = GetComponent<Rigidbody>();
        xRotation = 0;
        yRotation = 0;
    }


    void Update()
    {
        Vector3 forwardDir = Orientation.transform.forward;
        rb.AddForce(forwardDir.normalized*forwardForce*forwardMoveCoefficient);
        Vector3 horizontalDir = Orientation.transform.right;
        rigidBody.AddForce(horizontalDir.normalized*horizontalForce*horizontalMoveCoefficient);
        rb.AddForce(rb.velocity * rho * -1.0f);
        xRotation += xRotationSpeed;
        yRotation += yRotationSpeed;
        Orientation.transform.rotation = Quaternion.Euler(0,yRotation,0);
        LookDirection.transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
    }

    private void SpeedControl()
    {
    // 현재 Rigidbody의 속도 벡터
    Vector3 currentVelocity = rigidBody.velocity;

    // XZ 평면의 속도 벡터 (평행이동 속도)
    Vector3 flatVel = new Vector3(currentVelocity.x, 0f, currentVelocity.z);

    // 앞뒤 이동 속도 제한
    float forwardSpeedLimit = 10f; // 앞뒤 이동 속도의 상한선
    float limitedForwardVel = Mathf.Clamp(currentVelocity.y, -forwardSpeedLimit, forwardSpeedLimit);

    // 평행이동 속도 제한
    float moveSpeedLimit = 10f; // 평행이동 속도의 상한선
    if (flatVel.magnitude > moveSpeedLimit)
    {
        flatVel = flatVel.normalized * moveSpeedLimit;
    }

    // 제한된 속도를 Rigidbody에 적용
    rigidBody.velocity = new Vector3(flatVel.x, limitedForwardVel, flatVel.z);
    
    }
    
}
