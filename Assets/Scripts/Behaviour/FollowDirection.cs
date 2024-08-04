using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDirection : MonoBehaviour
{
    private Transform Orientation;
    // Start is called before the first frame update
    void Start()
    {
        Orientation = transform.parent.Find("Orientation");
    }

    // Update is called once per frame
    void Update()
    {
        if (Orientation == null)
        {
            Debug.Log("Orientation null error. FollowDirection disabled.");
            enabled = false;
            return;
        }
        transform.rotation = Orientation.rotation;
    }
}
