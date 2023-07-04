using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllrers : MonoBehaviour
{
    private float speed = 6.0f;
    private Rigidbody playerRb;
    private float zBoundUp = 11.0f;
    private float zBoundDown = -0.6f;
    private float reboundPlayer = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstainPlayerPosition();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Отскавиваем от стен.
        if (collision.gameObject.CompareTag("Wall"))
        {
            playerRb.AddForce(Vector3.right * reboundPlayer, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Wall1"))
        {
            playerRb.AddForce(Vector3.left * reboundPlayer, ForceMode.Impulse);
        }
    }
    void MovePlayer()
    {
        //Движение игрока.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }
    void ConstainPlayerPosition()
    {
        //Ограничить игрока выхода за верхнею и нижнею части экрана.
        if (transform.position.z < zBoundDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundDown);
        }
        if (transform.position.z > zBoundUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundUp);
        }
    }
}
