using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRock : MonoBehaviour
{
    private float rotateRock = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RotationRocks()
    {
        transform.Rotate(Vector3.forward * rotateRock);
    }
}
