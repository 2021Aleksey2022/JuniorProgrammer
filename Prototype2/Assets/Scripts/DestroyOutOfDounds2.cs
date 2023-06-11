using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfDounds2 : MonoBehaviour
{
    private float leftBound = -35.0f;
    private float rightBound = 35.0f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if(transform.position.x > rightBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
    }
}
