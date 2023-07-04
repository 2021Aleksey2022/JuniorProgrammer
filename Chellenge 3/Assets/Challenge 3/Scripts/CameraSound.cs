using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSound : MonoBehaviour
{
    private PlayerControllerX playerControllerX;
    private AudioSource cameraSource;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerX = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        cameraSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerX.gameOver == true)
        {
            cameraSource.Stop();
        }
    }
}
