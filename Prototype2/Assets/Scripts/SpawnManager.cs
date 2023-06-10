using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Reference to an array of animals
    public GameObject[] animalPrefab;
    //The position of the animals on the X axis
    private float spawnRangeX = 20.0f;
    //The position of animals on the Z axis
    private float spawnPosZ = 20.0f;
    //The initial time of creation of the animal
    private float initialTime = 1.5f;
    //The final time of creation of the animal
    private float finalTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Creating an animal with a random time interval
        InvokeRepeating("SpawnRandomAnimal", 2, Random.Range(initialTime, finalTime));
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    //Method of creating animals
    void SpawnRandomAnimal()
    {
        //The length of the array of random animals, assign to a variable
        int animalIndex = Random.Range(0, animalPrefab.Length);
        //Random position of animals on the X axis
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        //Random creation of animals
        Instantiate(animalPrefab[animalIndex], spawnPos, animalPrefab[animalIndex].transform.rotation);
    }
}
