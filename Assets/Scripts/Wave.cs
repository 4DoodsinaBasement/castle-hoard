using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    
    public int delay;
    int nextGroup = 0;
    float targetTime = 0;
    public GameObject[] groups;
        
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if((Time.time >= targetTime + delay) && (nextGroup < groups.Length))
        {
            EnemySpawn[] squads = groups[nextGroup].GetComponents<EnemySpawn>();
            for (int j = 0; j < squads.Length; j++)
            {
                groups[nextGroup].GetComponent<EnemySpawn>().Spawn();
            }
            nextGroup++;
            targetTime = Time.time + delay;
        }

    }
}
