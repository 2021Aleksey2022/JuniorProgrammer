using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //√раница  за которой снар€д(пицца) удал€етс€
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        //√раница за которой животные удал€ютс€
        else if(transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            gameManager.AddLives(-1);
        }
    }
}
