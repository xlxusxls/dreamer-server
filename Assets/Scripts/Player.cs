using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    
    void Start()
    {
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow key");
    }

    void MovePlayer()
    {
        float moveSpeed=10f*Time.deltaTime;

        float xvalue=Input.GetAxis("Horizontal")*moveSpeed;
        float yvalue=0;
        float zvalue=Input.GetAxis("Vertical")*moveSpeed ;

        transform.Translate(xvalue, yvalue , zvalue);
    }



}
