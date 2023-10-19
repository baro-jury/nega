using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] weaponPrefab;
    private float spawnRangeX = 20.0f;
    private float spawnRangeZ = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, 5f);
        InvokeRepeating("SpawnWeapon", 5, 10f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        int weaponIndex = Random.Range(0, weaponPrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.5f, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
    }
    void SpawnWeapon()
    {
        int weaponIndex = Random.Range(0, weaponPrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(weaponPrefab[weaponIndex], spawnPos, weaponPrefab[weaponIndex].transform.rotation);
    }
}
