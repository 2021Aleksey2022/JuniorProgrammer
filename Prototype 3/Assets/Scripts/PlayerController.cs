using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Ссылка на системы частиц при столкновении с припятствием.
    public ParticleSystem explosionPatricle;
    //Ссылка на эффект частиц из под ног
    public ParticleSystem dirtParticle;
    //Ссылка на музыку прыжка.
    public AudioClip jumpSound;
    //Ссылка на музыку столкновения.
    public AudioClip crashSound;
    //Сила прыжка.
    public float jumpForce = 10;
    //Переменная для проверки, игрок находится на земле или нет.
    public bool isOnGround = true;
    //Состояние игры
    public bool gameOver;
    //Гравитация.
    public float gravityModifier;
    //Жесткое тело
    private Rigidbody playerRb;
    //Ссылка на Аниматора
    private Animator playerAnim;
    private AudioSource playerSound;

    void Start()
    {
        //Получаем компонент Rigidbody
        playerRb = GetComponent<Rigidbody>();
        //Гравитация при прыжке
        Physics.gravity *= gravityModifier;
        //Получаем компонент Animator
        playerAnim = GetComponent<Animator>();
        playerSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Если нажат пробел , и проверяет игрок на земле ? и игра не оконченна ?
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //Останавливаем эффект частиц.
            dirtParticle.Stop();
            //Прыжок игрока.
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Игрок в прыжке(в воздухе).
            isOnGround = false;
            //Анимация прыжка
            playerAnim.SetTrigger("Jump_trig");
            playerSound.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Прверяем, по тегу, столкнулся ли игрок с Ground. 
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Установили значение, когда коллайдеры игрока и земли сопрекасаются между собой.
            isOnGround = true;
            //Проигрывем эффект чфстиц, когда игрок на земле.
            dirtParticle.Play();
        }
        //Проверяем, по тегу, столкнулся ли игрок с препятствием.
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            //Устанавливаем зничение состояния игры, игра останавливается
            gameOver = true;
            //Анимация смерти
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            //Проигрывем эффект частиц, когда игрок столкнулся с припятствием.
            explosionPatricle.Play();
            //Останавливаем эффект частиц из  под ног, когда игрок умер.
            dirtParticle.Stop();
            playerSound.PlayOneShot(crashSound, 1.0f);
        }
    }
}
