using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static short thiefValue;
    public static short belowValue;
    public static short gameMode;  // 1: 큰 도둑 잡기, 2: 작은 도둑 잡기
    public static bool goToDecide;
    public static bool killedThief;
    public static bool gameEnd;

    public GameObject[] thief;
    public GameObject[] playerNumber;
    public GameObject digit10Location;
    public GameObject digit1Location;
    public GameObject damagedScreen;
    public Text stateText;
    GameObject digit10;
    GameObject digit1;
    public int score;
    
    /*public Camera camera;
    float camera_Height;
    float camera_Width;
    float MinX;
    float MaxX;
    float MinY;
    float MaxY;*/

    void Start()
    {
        initialize();

        /*camera_Height = 2 * camera.orthographicSize;
        camera_Width = camera_Height * camera.aspect;

        MinX = (camera_Width / 2) * -1;
        MaxX = camera_Width / 2;
        MinY = (camera_Height / 2) * -1;
        MaxY = camera_Height / 2;*/
    }

    void initialize()
    {
        score = 0;

        digit10 = null;
        digit1 = null;

        GameController.goToDecide = false;
        GameController.killedThief = false;
        GameController.gameEnd = false;

        StartCoroutine("createThief");
    }

    void Update()
    {
        if (GameController.goToDecide)
        {
            if (GameController.gameMode == 1)
            {
                if (GameController.thiefValue > GameController.belowValue && GameController.killedThief)
                {
                    addScore();
                }
                else if (GameController.thiefValue <= GameController.belowValue && !GameController.killedThief)
                {
                    addScore();
                }
                else
                {
                    subtractScore();
                }
            }
            else if (GameController.gameMode == 2)
            {
                if (GameController.thiefValue < GameController.belowValue && GameController.killedThief)
                {
                    addScore();
                }
                else if (GameController.thiefValue >= GameController.belowValue && !GameController.killedThief)
                {
                    addScore();
                }
                else
                {
                    subtractScore();
                }
            }

            GameController.killedThief = false;
            GameController.goToDecide = false;
        }
    }

    void addScore()
    {
        score += 10;
    }

    void subtractScore()
    {
        score -= 10;
        GameObject go = Instantiate(damagedScreen, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        Destroy(go, 0.1f);
    }

    IEnumerator createThief()
    {
        GameController.thiefValue = randomNumber(10, 99);
        GameController.belowValue = randomNumber(10, 99);

        if (digit10 != null)
            Destroy(digit10.gameObject);
        if (digit1 != null)
            Destroy(digit1.gameObject);

        GameController.gameMode = randomNumber(1, 2);

        if (GameController.gameMode == 1)
            stateText.text = "큰 도둑 잡기";
        else if (GameController.gameMode == 2)
            stateText.text = "작은 도둑 잡기";

        digit10 = Instantiate(
                    playerNumber[GameController.belowValue / 10],
                    new Vector3(digit10Location.transform.position.x, digit10Location.transform.position.y, 0.0f),
                    Quaternion.identity
                    );

        digit1 = Instantiate(
                    playerNumber[GameController.belowValue % 10],
                    new Vector3(digit1Location.transform.position.x, digit1Location.transform.position.y, 0.0f),
                    Quaternion.identity
                    );

        short rn = randomNumber(0, 1);
        /*GameObject o = (GameObject)
            Instantiate(
                thief[rn],
                new Vector3(randomNumber(MinX + thief[rn].transform.lossyScale.x, MaxX - thief[rn].transform.lossyScale.x),
                    randomNumber(MinY + thief[rn].transform.lossyScale.y, MaxY - thief[rn].transform.lossyScale.y),
                    0.0f),
                Quaternion.identity
            );*/
        GameObject go = (GameObject) Instantiate(thief[rn], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        yield return new WaitForSeconds(5.0f);
        StartCoroutine("createThief");
    }

    short randomNumber(int min, int max)
    {
        return (short) UnityEngine.Random.Range(min, max + 1);
    }
}
