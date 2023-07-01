using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Ссылка на препятствие.
    public GameObject obstaclePrefab;
    //Позиция создания припятствия.
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    //Через 2 секунды начнуться создаваться припятствия.
    private float startDelay = 2.0f;
    //Каждые 2 секунды создаются припятствия.
    private float repeatRate = 2.0f;
    //Ссылка на класс PlayerController
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        //Ищем в сцене объект Player, обращаемся к компонентам класса PlayerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //Создание припятствия с интервалом времени(старт и промежуток).Вызвая метод котрый созаёт припятствия.
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //Метод создания припятствия.
    void SpawnObstacle()
    {
        //Пока игра не закончена
        if (playerControllerScript.gameOver == false)
        {
            //Создание припятствия.
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
