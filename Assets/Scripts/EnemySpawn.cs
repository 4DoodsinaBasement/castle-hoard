using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyObject;
    public int numberEnemies = 10;
    public float radius = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnLocation;
        
        for (int i = 0; i < numberEnemies; i++)
        {
            spawnLocation = Random.insideUnitCircle.normalized * (radius * (1 + Random.value));
            Instantiate(enemyObject, spawnLocation, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
