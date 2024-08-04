using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalInput : MonoBehaviour
{

    private float mouseHorizontal;
    private float mouseVertical;

    public PlayerMovement playerMovement;
    public float keyVertical;
<<<<<<< HEAD
<<<<<<< HEAD
    public float keyHorizontal;
=======
    public float KeyHorizontal;
>>>>>>> 8c8aeda9a18718168c684636512b582fe59e3c7a
=======
    public float keyHorizontal;
>>>>>>> 5453a61204197e7da2206b29bc4afc7b9b47a54c
    private bool cursorLocked = true;
    public bool isJumpPressed()
    {
        return Input.GetKeyDown(KeyCode.Space); // TAB Î∞îÎ•º Ï†êÌîÑ ÏûÖÎ†•ÏúºÎ°ú ÏÇ¨Ïö©Ìï©ÎãàÎã§.
    }


    void Start()
    {
        mouseHorizontal = 0;
        mouseVertical = 0;
        playerMovement = GetComponent<PlayerMovement>();
        keyVertical = 0;
<<<<<<< HEAD
<<<<<<< HEAD
        keyHorizontal = 0;
=======
        KeyHorizontal = 0;
>>>>>>> 8c8aeda9a18718168c684636512b582fe59e3c7a
=======
        keyHorizontal = 0;
>>>>>>> 5453a61204197e7da2206b29bc4afc7b9b47a54c
        ToggleCursorLock(true);
    }


    void Update()
    {
        mouseHorizontal = Input.GetAxisRaw("Mouse X");
        mouseVertical = Input.GetAxisRaw("Mouse Y");
        playerMovement.xRotationSpeed = mouseVertical;
        playerMovement.yRotationSpeed = mouseHorizontal;
        keyVertical = Input.GetAxisRaw("Vertical");
        playerMovement.forwardForce = keyVertical;
<<<<<<< HEAD
<<<<<<< HEAD
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        playerMovement.horizontalForce = keyHorizontal;
=======
        KeyHorizontal = Input.GetAxisRaw("Horizontal");
        playerMovement.horizontalForce = KeyHorizontal;
>>>>>>> 8c8aeda9a18718168c684636512b582fe59e3c7a

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ESC ≈∞ÔøΩÔøΩ ƒøÔøΩÔøΩ ÔøΩÔøΩÔøΩ ÔøΩÔøΩÔøΩÔøΩ ÔøΩÔøΩÔøΩÔøΩ
=======
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        playerMovement.horizontalForce = keyHorizontal;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ESC ≈∞∑Œ ƒøº≠ ¿·±› ø©∫Œ ¡∂¿˝
>>>>>>> 5453a61204197e7da2206b29bc4afc7b9b47a54c
            ToggleCursorLock(!cursorLocked);
        }

    }

    void ToggleCursorLock(bool isLocked)
    {
        cursorLocked = isLocked;
        if (cursorLocked)
        {
            Debug.Log("Locked mouse");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
