using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform startingPoint;
    public float lerpSpeed;
    //Счёт.
    public float score;
    //Ссылка игрока.
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            if (playerControllerScript.doubleSpeed)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log("Score : " + score);
        }
    }
    IEnumerator PlayIntro()
    {
        //Начальная позиция движенияю.
        Vector3 startPos = playerControllerScript.transform.position;
        //Конечная позиция движения.
        Vector3 endPos = startingPoint.position;
        //Продолжительность нашего движения.
        float journeyLength = Vector3.Distance(startPos, endPos);
        //Расстояние, которое преодолели к настоящему времени
        //и какова доля расстояния в общей протяженности путешествия. 
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        0.5f);
        //Вычисление, чтоб поместить игрока вперёд.
        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos,
            fractionOfJourney);
            yield return null;
        }
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        1.0f);
        playerControllerScript.gameOver = false;
    }

}
