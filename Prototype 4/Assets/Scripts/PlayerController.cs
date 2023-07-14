using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    //Ссылка на камеру.
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;
    //Скорость игрока.
    public float speed = 5.0f;
    //Прверяем суперсилу, включена или выключена.
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
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
    }
    //Когда столкнулись с включением суперсилы.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            //Показывает что суперсила включилась.
            hasPowerup = true;
            //Активируем индикатор суперсилы.
            powerupIndicator.gameObject.SetActive(true);
            //Удалаем суперсилу.
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    //Интерфейс(куратина), включение выключится через 7 сек.
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        //Выключаем суперсилу.
        hasPowerup = false;
        //Выключаем индикатор суперсилы.
        powerupIndicator.gameObject.SetActive(false);
    }
    //Когда столкнулись с врагом.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //Получаем компонент жесткого тела врага.
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //Получение вектора отскока врага от игрока(Вычисление).
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            //Враг отскакивает от игрока(Движение) + суперсила(powerupStrength).
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            //Вывод в консоль.
            Debug.Log("Collided with: " + collision.gameObject.name + "with powerup set to " + hasPowerup);
        }
    }
}
