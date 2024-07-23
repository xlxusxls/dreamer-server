using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalInput : MonoBehaviour
{

private float mouseHorizontal;
private float mouseVertical;

public PlayerMovement playerMovement;
public float keyVertical;
public float KeyHorizontal;


    void Start()
    {
      mouseHorizontal = 0;
      mouseVertical = 0;
      playerMovement = GetComponent<PlayerMovement>();
      keyVertical = 0;
      KeyHorizontal = 0;
    }


    void Update()
    {
        mouseHorizontal = Input.GetAxisRaw("Mouse X");
        mouseVertical = Input.GetAxisRaw("Mouse Y");
        playerMovement.xRotationSpeed = mouseVertical;
        playerMovement.yRotationSpeed = mouseHorizontal;
        keyVertical = Input.GetAxisRaw("Vertical");
        playerMovement.forwardForce = keyVertical;
        KeyHorizontal = Input.GetAxisRaw("Horizontal");
        playerMovement.horizontalForce = KeyHorizontal;
    }
}
