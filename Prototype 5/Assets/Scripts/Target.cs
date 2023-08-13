using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 8;
    private float maxSpeed = 10;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -4;
    private int pointRandomBad;
    private int pointRandomGood;

    public ParticleSystem explisionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        RandomPoint();
    }
    private void OnMouseDown()
    {
        MouseClick();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }
    private void MouseClick()
    {
        if (gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointRandomBad);
            SpawnGood();
        }
        else if (gameObject.CompareTag("Good1"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointRandomGood);
            SpawnGood();
        }
        else if (gameObject.CompareTag("Good2"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointRandomGood);
            SpawnGood();
        }
        else if (gameObject.CompareTag("Good3"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointRandomGood);
            SpawnGood();
        }
    }
    private void RandomPoint()
    {
        pointRandomGood = Random.Range(5, 20);
        pointRandomBad = Random.Range(-10, -40);
    }
    public void SpawnGood()
    {
        if (gameManager.isGameActive)
        {
            Instantiate(explisionParticle, transform.position, explisionParticle.transform.rotation);
        }
    }
}
