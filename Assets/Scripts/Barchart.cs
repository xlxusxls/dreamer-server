using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barchart : MonoBehaviour
{
    public GameObject Player;
    private float Playerpoint;
    private RectTransform recttransform;


    // Start is called before the first frame update
    void Start()
    
    {
       Playerpoint = -1.0f;

       recttransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Playerpoint = Player.GetComponent<PlayerPoint>().getPoint();
            if(Playerpoint <= 0.0f)
            {
                gameObject.SetActive(false);
            }
            recttransform.localScale = new Vector3(1, Playerpoint, 1);
        }   
    }
}
