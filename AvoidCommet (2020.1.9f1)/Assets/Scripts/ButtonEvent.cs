using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public GameObject mitsuha;
    PlayerController playerController;

    void Start()
    {
        playerController = mitsuha.GetComponent<PlayerController>();
    }

    public void leftButtonDown()
    {
        playerController.leftMove = true;
    }

    public void leftButtonUp()
    {
        playerController.leftMove = false;
    }

    public void rightButtonDown()
    {
        playerController.rightMove = true;
    }

    public void rightButtonUp()
    {
        playerController.rightMove = false;
    }
}
