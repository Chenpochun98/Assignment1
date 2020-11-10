using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enemyspawn : MonoBehaviour
{
    // Start is called before the first frame update
    private static enemyspawn m_Instance;
    public int mcount = 0;
    //public int count
    //{ get { return mcount; } set { mcount = value; } }
    public static enemyspawn Instance
    { get { return m_Instance; } }
    public GameObject enemy;
    public GameObject spawnpoint;
    public int enemycount;
    public int enemyspawnnumber = 10;
    int i;

    public void OnEnable()
    {
        StartCoroutine(Enemyspawn());
        m_Instance = this;
    }
    
    IEnumerator Enemyspawn()
    {
        while(enemycount< enemyspawnnumber)
        {
            Instantiate(enemy, new Vector3(spawnpoint.transform.position.x + i, spawnpoint.transform.position.y, spawnpoint.transform.position.z),Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemycount++;
            i+=10;
           
        }
    }

    private void Update()
    {
        if (enemyspawnnumber == mcount)
        {
            print("WIN");
            Time.timeScale = 0;
            SceneManager.LoadScene("midterm");
        }
    }

}
