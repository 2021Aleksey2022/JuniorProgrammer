using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float cubeScale = 2.0f;
    private float speedCube = 10.0f;
    private float xRange = 5.0f;
    private float yRange = 6.0f;
    private float zRange = 14.0f;
    
    void Start()
    {
        transform.position = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 
            Random.Range(-zRange, zRange));
        transform.localScale = Vector3.one * cubeScale;
        
        Material material = Renderer.material;
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }

    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime * speedCube, 0.0f, 0.0f);
    }
    
}
