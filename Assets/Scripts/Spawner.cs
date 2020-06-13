using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] pickupPrefabs;

    public GameObject[] environmentPrefabs;

    public float spawnRadius = 2;

    public int enemyCount = 10;
    public int pickupCount = 10;
    public int environmentCount = 10;
    
    void Awake()
    {
        Spawn(enemyPrefabs, enemyCount);
        //Spawn(pickupPrefabs, pickupCount);
        Spawn(environmentPrefabs, environmentCount);
    }

    void Spawn(GameObject[] prefabs, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int j = Random.Range(0, prefabs.Length);
            GameObject newObj = Instantiate(prefabs[j]);

            Vector3 pos = Random.insideUnitSphere * spawnRadius; 
            newObj.transform.position = pos;
            
        }
    }


}
