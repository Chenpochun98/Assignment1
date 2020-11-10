using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject spawnpoint;
    public int enemycount;
    int i;
    public void OnEnable()
    {
        StartCoroutine(Enemyspawn());
    }
    
    IEnumerator Enemyspawn()
    {
        while(enemycount<9)
        {
            Instantiate(enemy, new Vector3(spawnpoint.transform.position.x + i, spawnpoint.transform.position.y, spawnpoint.transform.position.z),Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemycount++;
            i+=10;
           
        }
    }
 
}
