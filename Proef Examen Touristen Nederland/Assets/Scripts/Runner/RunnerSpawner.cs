using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawner : MonoBehaviour
{

    public GameObject[] Spawners;
    public GameObject Prefab;

    private void Start()
    {
        InvokeRepeating("SpawnTruck", 1, 2);
    }

    void SpawnTruck()
    {
        Instantiate(Prefab, Spawners[Random.Range(0, Spawners.Length - 1)].transform.position, Quaternion.identity);
    }
}
