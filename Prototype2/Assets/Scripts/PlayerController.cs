using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    //Player movement variable
    private float horizontalInput;
    private float verticalInput;
    //Variable player movement speed
    private float speed = 15.0f;
    private float vertncalSpeed = 25.0f;
    //Link to animal prefab
    [SerializeField]private GameObject projectilePrefab;
    //The variable of the limit of the player's boundary, beyond which he cannot go
    private float xRange = 20.0f;
    private float zTopRange = 6.0f;
    private float zLowerRange = -0.5f;
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
            Instantiate(projectilePrefab, projectileSpawnPoint.position,
                       projectilePrefab.transform.rotation);

        }
        //Player movement on the X-axis
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //Player movement on the Z-axis
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * vertncalSpeed);
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
        if (transform.position.z < zLowerRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerRange);
        }
        else if (transform.position.z > zTopRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopRange);
        }
    }
}
