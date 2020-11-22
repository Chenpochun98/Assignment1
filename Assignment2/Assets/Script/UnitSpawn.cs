using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject UnitPrefab;
    public int waveNumber;
    public int enemiesPerWave;
    public int secondBetweenWaves;
    public int secondStartDelay;
    public int pathid;

    private int currentWave = 0; 

    private waypointmanager.path _Path;

    public void Init(waypointmanager.path Path)
    {
        _Path = Path;
    }
    public void StartSpawner()
    {
        StartCoroutine("BeginWaveSpawn");
    }

    private IEnumerator BeginWaveSpawn()
    {
        yield return new WaitForSeconds(secondStartDelay);

        while (currentWave < waveNumber)
        {
            yield return SpawnWave(currentWave++);
            yield return new WaitForSeconds(secondBetweenWaves);
        }
    }
    private IEnumerator SpawnWave(int wavesNumber)
    {
        for (int i = 0; i < enemiesPerWave; ++i)
        {
            GameObject unitGO = Instantiate(UnitPrefab, transform.position, Quaternion.identity);
            unitGO.GetComponent<enemy>().Init(_Path);
            yield return new WaitForSeconds(0.5f);
        }
      
    }
}
