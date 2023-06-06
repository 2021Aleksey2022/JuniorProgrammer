using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player movement variable
    public float horizontalInput;
    //Variable player movement speed
    public float speed = 30.0f;
    //Link to animal prefab
    public GameObject projectilePrefab;
    //The variable of the limit of the player's boundary, beyond which he cannot go
    private float xRange = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Creating a projectile (pizza) if the left mouse button is pressed
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        //Player movement on the X-axis
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
    private void LateUpdate()
    {
        //The boundaries of the player, beyond which he cannot go
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
