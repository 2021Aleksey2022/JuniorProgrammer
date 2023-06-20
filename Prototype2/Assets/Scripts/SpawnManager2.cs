using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefab2;
    private float spawnRangeXMaxLeft = -39.0f;
    private float spawnRangeXMinLeft = -33.0f;
    private float spawnRangeZLeftMax = 12.0f;
    private float spwnRangeZLeftMin = 5.0f;
    private float startDelayLeft = 2.0f;
    private float startTimeLeft = 1.5f;
    private float endTimeLeft = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimalRandom2", startDelayLeft, Random.Range(startTimeLeft, endTimeLeft));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnAnimalRandom2()
    {
        int indexAnimals2 = Random.Range(0, animalPrefab2.Length);
        Vector3 spawnPos2 = new Vector3(Random.Range(spawnRangeXMaxLeft, spawnRangeXMinLeft), 0, Random.Range(spwnRangeZLeftMin, spawnRangeZLeftMax));
        Instantiate(animalPrefab2[indexAnimals2], spawnPos2, animalPrefab2[indexAnimals2].transform.rotation);
    }
}
