using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Transform[] Terrains;
    public Transform TerrainSpawnPoint;

    public void RandomGenerator()
    {
        Transform RandItem = Terrains[Random.Range(0, Terrains.Length)];

        Instantiate(RandItem, TerrainSpawnPoint.position, Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "AddGround")
        {
            if (collision.gameObject.layer == 6)
            {
                RandomGenerator();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "RemoveGround")
        {
            if (!collision.gameObject.CompareTag("Donkey"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
