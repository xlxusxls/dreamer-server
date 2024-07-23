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
    public float horizontalMoveSpeed;
    public float forwardMoveSpeed;
    public float xRotationSpeed;
    public float yRotationSpeed;
    public float JumpForce;
   
    
    void Start()
    {
     forwardForce = 0;
     horizontalForce = 0;
     horizontalMoveSpeed = 4;
     forwardMoveSpeed = 4;
     xRotationSpeed = 0;
     yRotationSpeed = 0;
     JumpForce = 0;
     rigidBody = GetComponent<Rigidbody>();
     xRotation = 0;
     yRotation = 0;
     forwardDirection = 0;
     horizontalDirection = 0;
    }
private Rigidbody rigidBody;
private float xRotation;
private float yRotation;
private float forwardDirection;
private float horizontalDirection;

    void Update()
    {
     xRotation += xRotationSpeed;
     yRotation += yRotationSpeed;
     Orientation.transform.rotation = Quaternion.Euler(0,yRotation,0);
     LookDirection.transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
     Vector3 forwardDir = Orientation.transform.forward;
     rigidBody.AddForce(forwardDir.normalized * forwardMoveSpeed * 4f * forwardForce, ForceMode.Force);
     forwardDirection += forwardMoveSpeed;
     
     Vector3 horizontalDir = Orientation.transform.right;
     rigidBody.AddForce(horizontalDir.normalized * horizontalMoveSpeed * 4f * horizontalForce, ForceMode.Force);
     horizontalDirection += horizontalMoveSpeed;

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
