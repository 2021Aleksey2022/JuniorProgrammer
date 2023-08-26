using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 45.0f;
    [SerializeField] private float rpm;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI spedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Move the vehicle forward
        // Двигать транспортное средство вперёд     
        
        
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            spedometerText.SetText("Speed: " + speed + " km/ph ");

            rpm = (speed % 30) * 60;
            rpmText.SetText("RPM: " + rpm);
        
    }
    
}
