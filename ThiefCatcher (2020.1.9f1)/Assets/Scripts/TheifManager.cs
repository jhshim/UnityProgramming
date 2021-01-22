using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheifManager : MonoBehaviour
{
    public GameObject[] thiefNumber;
    GameObject digit10Location;
    GameObject digit1Location;
    GameObject digit10;
    GameObject digit1;
    Animator animator;

    short order;
    float timeSpan;
    float checkTime;

    void Start()
    {
        digit10Location = transform.Find("Digit10Location").gameObject;
        digit1Location = transform.Find("Digit1Location").gameObject;
        animator = GetComponent<Animator>();

        order = 1;
        timeSpan = 0.0f;
        checkTime = 0.2f;
    }

    void Update()
    {
        timeSpan += Time.deltaTime;

        if (timeSpan > checkTime)
        {
            if (order == 1)
            {
                digit10 = Instantiate(
                    thiefNumber[GameController.thiefValue / 10],
                    new Vector3(digit10Location.transform.position.x, digit10Location.transform.position.y, 0.0f),
                    Quaternion.identity
                    );

                digit1 = Instantiate(
                    thiefNumber[GameController.thiefValue % 10],
                    new Vector3(digit1Location.transform.position.x, digit1Location.transform.position.y, 0.0f),
                    Quaternion.identity
                    );

                checkTime = 3.0f;
                timeSpan = 0.0f;
                order = 2;
            }
            else if (order == 2)
            {
                Destroy(digit10.gameObject);
                Destroy(digit1.gameObject);
                Destroy(this.gameObject, 0.3f);
                animator.SetBool("remove", true);

                GameController.goToDecide = true;
                order = -1;
            }
        }
    }
    private void OnMouseDown()
    {
        Destroy(digit10.gameObject);
        Destroy(digit1.gameObject);
        Destroy(this.gameObject, 0.1f);
        animator.SetBool("kill", true);
        GameController.killedThief = true;
        GameController.goToDecide = true;
    }
}