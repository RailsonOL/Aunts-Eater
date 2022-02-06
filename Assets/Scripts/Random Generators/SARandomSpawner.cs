using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SARandomSpawner : MonoBehaviour
{
    [Header("Sexy Appeal Points")]
    public Transform[] SpawnPoints;
    public GameObject[] ItemPrefab;

    [Header("Traps Spawn")]
    public Transform SpawnPointTrap;
    public GameObject[] Traps;
    public GameObject Donkey;
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomPoints), 0, 2.5f);
        InvokeRepeating(nameof(SpawnTraps), 0, 15f);
        InvokeRepeating(nameof(SpawnDonkey), 0, 10f);
    }

    public void SpawnRandomPoints()
    {
        Transform RandPosition = SpawnPoints[Random.Range(0, SpawnPoints.Length)];

        Instantiate(ItemPrefab[Random.Range(0, ItemPrefab.Length)], RandPosition.position, Quaternion.identity);
    }

    public void SpawnTraps()
    {
        Instantiate(Traps[Random.Range(0, Traps.Length)], SpawnPointTrap.position, Quaternion.identity);
    }

    public void SpawnDonkey()
    {
        int rng = Random.Range(0, 10);

        if(rng == 5 || rng == 7)
        {
            Instantiate(Donkey, SpawnPointTrap.position, Quaternion.identity);
        }
    }
}
