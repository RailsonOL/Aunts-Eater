using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    MeshRenderer mr;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameObject.name)
        {
            case "Paralax1":
                mr.material.mainTextureOffset += Vector2.right * 0.05f * Time.deltaTime;
                break;
            case "Paralax2":
                mr.material.mainTextureOffset += Vector2.right * 0.1f * Time.deltaTime;
                break;
        }   
    }
}
