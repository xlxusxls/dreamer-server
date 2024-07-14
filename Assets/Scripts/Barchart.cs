using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barchart : MonoBehaviour
{
    public GameObject Player;
    private int Playerpoint;
    private RectTransform recttransform;


    // Start is called before the first frame update
    void Start()
    
    {
       Playerpoint= -1;

       recttransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Playerpoint = Player.GetComponent<PlayerPoint>().getPoint();
        recttransform.localScale = new Vector3(1, Playerpoint/10,1);



    }
}
