using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public List<UnitSpawn> spawns;

    private waypointmanager Waypointmanager;

    public void Initialized(waypointmanager wpManger)
    {
        Waypointmanager = wpManger;
        foreach(UnitSpawn spawn in spawns)
        {
            spawn.Init(Waypointmanager.GetPath(spawn.pathid));
        }
    }

    public void Startspawner()
    {
        foreach (UnitSpawn spawn in spawns)
        {
            spawn.StartSpawner();
        }
    }
}
 
