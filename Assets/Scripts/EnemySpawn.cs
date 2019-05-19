using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public GameObject SpawnType; 
    private GameObject[] eligibleSpawnLocations;
    public int enemiesToSpawn;
    private int arrayEnd;
    int offset = 0;

    // Start is called before the first frame update
    public void Spawn()
    {
        eligibleSpawnLocations =  GameObject.FindGameObjectsWithTag(SpawnType.tag);
        arrayEnd = eligibleSpawnLocations.Length -1;

        for (int i = 0; i<enemiesToSpawn; i++)
        {
            if(arrayEnd == -1)
            {
                arrayEnd = eligibleSpawnLocations.Length-1;
                offset++;
            }
            int j = Random.Range(0, arrayEnd);
            GameObject locationToSpawn = eligibleSpawnLocations[j];
            Vector3 location = new Vector3(
                locationToSpawn.transform.position.x, // + (offset *5),
                locationToSpawn.transform.position.y,
                locationToSpawn.transform.position.z
                );
  
            Instantiate(enemyToSpawn, location, locationToSpawn.transform.rotation);
            swap(arrayEnd, j);
            arrayEnd--;
        }
    }

    void swap(int a, int b)
    {
        GameObject temp = eligibleSpawnLocations[a];
        eligibleSpawnLocations[a] = eligibleSpawnLocations[b];
        eligibleSpawnLocations[b] = temp;
    }


}
