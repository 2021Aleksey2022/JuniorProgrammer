using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //������ �� �����������.
    public GameObject[] obstaclePrefab;
    //������� �������� �����������.
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    //����� 2 ������� ��������� ����������� �����������.
    private float startDelay = 2.0f;
    //������ 2 ������� ��������� �����������.
    private float repeatRate = 2.0f;
    //��������� �����������.
    private int randomObstacle;
    //������ �� ����� PlayerController
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        //���� � ����� ������ Player, ���������� � ����������� ������ PlayerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //�������� ����������� � ���������� �������(����� � ����������).������ ����� ������ ����� �����������.
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //����� �������� �����������.
    void SpawnObstacle()
    {
        //���� ���� �� ���������
        if (playerControllerScript.gameOver == false)
        {
            randomObstacle = Random.Range(0, obstaclePrefab.Length);
            //�������� �����������.
            Instantiate(obstaclePrefab[randomObstacle], spawnPos, obstaclePrefab[randomObstacle].transform.rotation);
        }
    }
}
