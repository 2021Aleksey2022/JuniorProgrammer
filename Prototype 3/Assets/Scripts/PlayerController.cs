using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool doubleSpeed = false;
    //�������� , ������������ ������� ������.
    public bool doubleJumpUsed = false;
    // ���� �������� �������.
    public float doubleJumpForce;
    //������ �� ������� ������ ��� ������������ � ������������.
    public ParticleSystem explosionPatricle;
    //������ �� ������ ������ �� ��� ���
    public ParticleSystem dirtParticle;
    //������ �� ������ ������.
    public AudioClip jumpSound;
    //������ �� ������ ������������.
    public AudioClip crashSound;
    //���� ������.
    public float jumpForce = 10;
    //���������� ��� ��������, ����� ��������� �� ����� ��� ���.
    public bool isOnGround = true;
    //��������� ����
    public bool gameOver;
    //����������.
    public float gravityModifier;
    //������� ����
    private Rigidbody playerRb;
    //������ �� ���������
    private Animator playerAnim;
    private AudioSource playerSound;

    void Start()
    {
        //�������� ��������� Rigidbody
        playerRb = GetComponent<Rigidbody>();
        //���������� ��� ������
        Physics.gravity *= gravityModifier;
        //�������� ��������� Animator
        playerAnim = GetComponent<Animator>();
        playerSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        //���� ����� ������ , � ��������� ����� �� ����� ? � ���� �� ��������� ?
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //������������� ������ ������.
            dirtParticle.Stop();
            //������ ������.
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //����� � ������(� �������).
            isOnGround = false;
            //�������� ������
            playerAnim.SetTrigger("Jump_trig");
            playerSound.PlayOneShot(jumpSound, 1.0f);
            doubleJumpUsed = false;
        }
        //������� ������
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !doubleJumpUsed)
        {
            doubleJumpUsed = true;
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnim.Play("Running_Jump", 3, 0f);
            playerSound.PlayOneShot(jumpSound, 1.0f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        //��������, �� ����, ���������� �� ����� � Ground. 
        if (collision.gameObject.CompareTag("Ground"))
        {
            //���������� ��������, ����� ���������� ������ � ����� ������������� ����� �����.
            isOnGround = true;
            //���������� ������ ������, ����� ����� �� �����.
            dirtParticle.Play();
        }
        //���������, �� ����, ���������� �� ����� � ������������.
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            //������������� �������� ��������� ����, ���� ���������������
            gameOver = true;
            //�������� ������
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            //���������� ������ ������, ����� ����� ���������� � ������������.
            explosionPatricle.Play();
            //������������� ������ ������ ��  ��� ���, ����� ����� ����.
            dirtParticle.Stop();
            playerSound.PlayOneShot(crashSound, 1.0f);
        }
    }
}
