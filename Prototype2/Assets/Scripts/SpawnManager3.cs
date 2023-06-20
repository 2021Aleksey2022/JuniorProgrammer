using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs3;
    private float spawnRangeXMaxRight = 38.0f;
    private float spawnRangeXMinRight = 33.0f;
    private float spawnRangeZRightMax = 13.0f;
    private float spawnRangeZRightMin = 4.0f;
    private float startDelayRight = 2.0f;
    private float startTimeRight = 1.0f;
    private float endTimeRight = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimalsPrefab3", startDelayRight, Random.Range(startTimeRight, endTimeRight));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnAnimalsPrefab3()
    {
        int indexAnimals3 = Random.Range(0, animalPrefabs3.Length);
        Vector3 spawnPos3 = new Vector3(Random.Range(spawnRangeXMinRight, spawnRangeXMaxRight),
            0, Random.Range(spawnRangeZRightMin, spawnRangeZRightMax));
        Instantiate(animalPrefabs3[indexAnimals3], spawnPos3,
            animalPrefabs3[indexAnimals3].transform.rotation);
    }
}
