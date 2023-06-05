using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Ссылка на массив животных
    public GameObject[] animalPrefab;
    //Позиция животных по оси Х
    private float spawnRangeX = 20.0f;
    //Позиция животных по оси Z
    private float spawnPosZ = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //При нажатии пробела, создаём животое
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Длина массива рандомных животных, присваеваем в переменную
            int animalIndex = Random.Range(0, animalPrefab.Length);
            //Рандомная позиция животных
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            //Рандомное создание животных
            Instantiate(animalPrefab[animalIndex], spawnPos, animalPrefab[animalIndex].transform.rotation);


        }
    }
}
