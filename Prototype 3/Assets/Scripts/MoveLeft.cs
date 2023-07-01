using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //�������� �����������.
    public float speedObstacle = 15.0f;
    //������ �� ����� PlayerController
    private PlayerController playerControllerScript;
    //���� �������, �� ������� ����������� ���������.
    private float leftBound = -15.0f;
    // Start is called before the first frame update
    void Start()
    {
        //���� ������ Player, ���������� � ����������� ������ PlayerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���� �� ���������
        if (playerControllerScript.gameOver == false)
        {
            //�������� ����� ����������� � Background.
            transform.Translate(Vector3.left * Time.deltaTime * speedObstacle);
        }
        //��������� ������� �����������, ���� ������ ���� �������, �� ���� ���������� � �����������.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            //� ������� �����������
            Destroy(gameObject);
        }
    }  
}
