using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    void Update()
    {
        transform.position += GameController.instance.SpawnVelocity * Time.deltaTime * Vector3.right;
    }
}
