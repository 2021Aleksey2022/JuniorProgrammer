using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float startSpwanDogsTime = 0.0f;
    private float spawnIntervalDogs = 2.0f;

    // Update is called once per frame
    void Start()
    {
       
    }
    void Update()
    {
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > (spawnIntervalDogs + startSpwanDogsTime))
            {
                GameObject myGameObject = (GameObject)Instantiate(dogPrefab);
                myGameObject.transform.position = gameObject.transform.position;
                startSpwanDogsTime = Time.time;
            }
        }
    }
}
