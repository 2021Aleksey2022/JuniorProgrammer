using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Ссылка на врага.
    public GameObject enemyPrefabs;
    public GameObject powerupPrefab;
    //Отсеживаем врагов.
    public int enemyCount;
    //Количество врагов.
    public int waveNumber = 1;
    //Граница создания врага.
    private float spawnRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Вызов метода создания врага.
        SpawnEnemyWave(waveNumber);
        //Создать суперсилу.
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //Отслеживаем когда все враги умрут(+1) и + суперсила.
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    //Метод создания врага.
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            //Создание врага.
            Instantiate(enemyPrefabs, GenerateSpawnPosition(), enemyPrefabs.transform.rotation);
        }
    }
    //Метод рандомной позиции.
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
