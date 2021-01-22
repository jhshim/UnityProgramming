using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timerTxt;
    public GameObject gameOverText;
    public static bool gameEnd;
    Stopwatch stopWatch;

    bool gameOverSwitch;

    // Start is called before the first frame update
    void Start()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();

        gameOverText.SetActive(false);
        gameOverSwitch = false;
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
}
