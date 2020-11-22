using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointmanager : MonoBehaviour
{
    [Serializable]
    public class path
    {
        public int Id;
        public List<Transform> Wapoints;
    }

    public List<path> Paths;

    public path GetPath(int Id)
    {
        return Paths[Id];
    }
}

