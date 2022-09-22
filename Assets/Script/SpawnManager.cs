using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject MultiBombPrefab;
    public Image[] waves;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyMovement>().Length;

        if(enemyCount == 0)
        {
            SpawnEnemyWave(waveNumber);
            SpawnMultiBomb();
            waves[waveNumber-1].gameObject.SetActive(true);
            StartCoroutine(WaveCountdownRoutine());
            waveNumber++;
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i=0; i<enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab , GenerateSpawnPos() , enemyPrefab.transform.rotation);
        }

    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX , 0 , spawnPosZ); 

        return randomPos;
    }

    IEnumerator WaveCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("enter");
        waves[waveNumber-2].gameObject.SetActive(false);
        
    }
    void SpawnMultiBomb()
    {
        Instantiate(MultiBombPrefab , GenerateSpawnPos(), MultiBombPrefab.transform.rotation);
    }
}
