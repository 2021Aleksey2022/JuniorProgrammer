using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    //Позиция BackGround
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        //Сохронем позицию в переменную
        startPos = transform.position;
        //Получаем компонент 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            //Возвращаем BackGround на стартовую позицию
            transform.position = startPos;
        }
    }
}
