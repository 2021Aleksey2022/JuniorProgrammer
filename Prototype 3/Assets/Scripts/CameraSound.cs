using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSound : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private AudioSource cameraSound;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        cameraSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == true)
        {
            cameraSound.Stop();
        }
    }
}
