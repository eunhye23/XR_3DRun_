using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSpawnManager : MonoBehaviour
{
    HRoadSpawn roadSpawn;

    void Start()
    {
        roadSpawn = GetComponent<HRoadSpawn>();
    }

   
    void Update()
    {
        
    }

    public void SpawnTriggerEnter()
    {
        roadSpawn.MoveRoad();
    }
}
