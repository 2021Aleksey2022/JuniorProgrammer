using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    //Ссылка на камеру.
    private GameObject focalPoint;
    private GameObject tmpRocket;
    private Coroutine powerupCountdown;
    private float powerupStrength = 15.0f;
    //Скорость игрока.
    public float speed = 5.0f;
    //Прверяем суперсилу, включена или выключена.
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    public PowerUpType currentPowerUp = PowerUpType.None;
    public GameObject rocketPrefab;
    public float hangTime;
    public float smashSpeed;
    public float explosionForce;
    public float explosionRadius;
    bool smashing = false;
    float floorY;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    void LaunchRockets()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up,
            Quaternion.identity);
            tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Считывание нажатие клавиш.
        float forwardInput = Input.GetAxis("Vertical");
        //Движение игрока.
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        //Позиция индикатора                  Поизиция игрока      Обновляем позицию
        powerupIndicator.transform.position = transform.position + new Vector3(0.0f -0.09f, 0.0f);
        if (currentPowerUp == PowerUpType.Rockets && Input.GetKeyDown(KeyCode.F))
        {
            LaunchRockets();
        }
        if (currentPowerUp == PowerUpType.Smash && Input.GetKeyDown(KeyCode.Space) && !smashing)
        {
            smashing = true;
            StartCoroutine(Smash());
        }
    }
    //Когда столкнулись с включением суперсилы.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            //Показывает что суперсила включилась.
            hasPowerup = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            //Активируем индикатор суперсилы.
            powerupIndicator.gameObject.SetActive(true);
            //Удалаем суперсилу.
            Destroy(other.gameObject);
            if (powerupCountdown != null)
            {
                StopCoroutine(powerupCountdown);
            }
            powerupCountdown = StartCoroutine(PowerupCountdownRoutine());

            //StartCoroutine(PowerupCountdownRoutine());
        }
    }
    //Интерфейс(куратина), включение выключится через 7 сек.
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        //Выключаем суперсилу.
        hasPowerup = false;
        currentPowerUp = PowerUpType.None;
        //Выключаем индикатор суперсилы.
        powerupIndicator.gameObject.SetActive(false);
    }
    IEnumerator Smash()
    {
        var enemies = FindObjectsOfType<Enemy>();
        //Store the y position before taking off
        floorY = transform.position.y;
        //Calculate the amount of time we will go up
        float jumpTime = Time.time + hangTime;
        while (Time.time < jumpTime)
        {
            //move the player up while still keeping their x velocity.
            playerRb.velocity = new Vector2(playerRb.velocity.x, smashSpeed);
            yield return null;
        }
        //Now move the player down
        while (transform.position.y > floorY)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, -smashSpeed * 2);
            yield return null;
        }
        //Cycle through all enemies.
        for (int i = 0; i < enemies.Length; i++)
        {
            //Apply an explosion force that originates from our position.
            if (enemies[i] != null)
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce,
                transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
        }
        //We are no longer smashing, so set the boolean to false
        smashing = false;
    }

    //Когда столкнулись с врагом.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup && currentPowerUp == PowerUpType.Pushback)
        {
            //Получаем компонент жесткого тела врага.
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //Получение вектора отскока врага от игрока(Вычисление).
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            //Враг отскакивает от игрока(Движение) + суперсила(powerupStrength).
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            //Вывод в консоль.
            Debug.Log("Collided with: " + collision.gameObject.name + "with powerup set to " +
                currentPowerUp.ToString());
        }
    }
}
