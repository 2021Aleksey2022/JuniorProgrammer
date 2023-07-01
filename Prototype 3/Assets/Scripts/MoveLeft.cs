using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //Скорость препятствия.
    public float speedObstacle = 15.0f;
    //Ссылка на класс PlayerController
    private PlayerController playerControllerScript;
    //Край границы, за которой припятствия удаляются.
    private float leftBound = -15.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Ищем объект Player, обращаемся к компонентам класса PlayerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Пока игра не закончена
        if (playerControllerScript.gameOver == false)
        {
            //Движение влево припятствия и Background.
            transform.Translate(Vector3.left * Time.deltaTime * speedObstacle);
        }
        //Проверяем позицию припятствия, если меньше края границы, по тегу обращаемся к припятствию.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            //И удаляем припятствие
            Destroy(gameObject);
        }
    }  
}
