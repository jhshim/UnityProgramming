using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timerTxt;
    public GameObject gameOverText;
    Stopwatch stopWatch;
    
    public static bool gameEnd;
    bool gameEndSwitch;

    // Start is called before the first frame update
    void Start()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();

        gameEndSwitch = false;
        gameOverText.SetActive(false);
        GameController.gameEnd = false;
    }

    public void Update()
    {
        if(!GameController.gameEnd)
            msToMinuteSecond();

        if (!gameEndSwitch)
        {
            if (GameController.gameEnd)
            {
                stopWatch.Stop();
                gameOverText.SetActive(true);
                gameEndSwitch = true;
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
