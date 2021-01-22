using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    public static bool gameEnd;

    public GameObject commet;
    public GameObject gameOverText;
    public Camera camera;
    public Text timerTxt;
    Stopwatch stopWatch;

    float camera_Width;
    float camera_Height;

    float MinX;
    float MaxX;
    float MinY;
    float MaxY;

    bool gameOverSwitch;

    // Start is called before the first frame update
    void Start()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();

        gameOverText.SetActive(false);
        gameOverSwitch = false;
        
        camera_Height = 2 * camera.orthographicSize;
        camera_Width = camera_Height * camera.aspect;

        MinX = (camera_Width / 2) * -1;
        MaxX = camera_Width / 2;
        MinY = (camera_Height / 2) * -1;
        MaxY = camera_Height / 2;

        StartCoroutine("createCommet");
        GameController.gameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameEnd)
            msToMinuteSecond();

        if (!gameOverSwitch)
        {
            if (GameController.gameEnd)
            {
                StopCoroutine("createCommet");
                gameOverText.SetActive(true);
                gameOverSwitch = true;
            }
        }
    }

    public void msToMinuteSecond()
    {
        int second = (int)(stopWatch.ElapsedMilliseconds / 1000);

        int minute = second / 60;
        second = second % 60;

        timerTxt.text = plus0AtLeft(minute) + ":" + plus0AtLeft(second);
    }

    public string plus0AtLeft(int number)
    {
        string numberString;

        if (number < 10)
            numberString = "0" + number;
        else
            numberString = number + "";

        return numberString;
    }

    IEnumerator createCommet()
    {
        short rn = (short) randomNumber(1, 2);

        for (int i = 0; i < rn; i++)
        {
            GameObject c = (GameObject)Instantiate(commet, new Vector3(randomNumber(MinX + commet.transform.lossyScale.x, MaxX - commet.transform.lossyScale.x), 11.0f, 0.0f), Quaternion.identity);
        }

        yield return new WaitForSeconds(0.5f);
        StartCoroutine("createCommet");
    }

    int randomNumber(int min, int max)
    {
        return (int) UnityEngine.Random.Range(min, max+1);
    }

    float randomNumber(float min, float max)
    {
        return UnityEngine.Random.Range(min, max + 1);
    }
}
