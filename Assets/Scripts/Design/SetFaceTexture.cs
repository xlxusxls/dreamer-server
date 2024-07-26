using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFaceTexture : MonoBehaviour
{
    MeshFilter cubeMesh;
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        cubeMesh = GetComponent<MeshFilter>();
        mesh = cubeMesh.mesh;
        Vector2[] uvMap = mesh.uv;

        uvMap[0] = new Vector2(0, 0);
        uvMap[1] = new Vector2(0.333f, 0);
        uvMap[2] = new Vector2(0, 0.333f);
        uvMap[3] = new Vector2(0.333f, 0.333f);

        uvMap[4] = new Vector2(0.333f, 0.333f);
        uvMap[5] = new Vector2(0.666f, 0.333f);
        uvMap[6] = new Vector2(0.333f, 0);
        uvMap[7] = new Vector2(0.666f, 0);

        uvMap[8] = new Vector2(0.333f, 0.333f);
        uvMap[9] = new Vector2(0.666f, 0.333f);
        uvMap[10] = new Vector2(0.333f, 0);
        uvMap[11] = new Vector2(0.666f, 0);

        uvMap[12] = new Vector2(0.333f, 0.333f);
        uvMap[13] = new Vector2(0.666f, 0.333f);
        uvMap[14] = new Vector2(0.333f, 0);
        uvMap[15] = new Vector2(0.666f, 0);

        uvMap[16] = new Vector2(0.333f, 0.333f);
        uvMap[17] = new Vector2(0.666f, 0.333f);
        uvMap[18] = new Vector2(0.333f, 0);
        uvMap[19] = new Vector2(0.666f, 0);

        uvMap[20] = new Vector2(0.333f, 0.333f);
        uvMap[21] = new Vector2(0.666f, 0.333f);
        uvMap[22] = new Vector2(0.333f, 0);
        uvMap[23] = new Vector2(0.666f, 0);

        mesh.uv = uvMap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
