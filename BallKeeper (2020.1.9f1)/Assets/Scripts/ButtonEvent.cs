using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour
{
    public GameObject bar;
    BarController barController;

    void Start()
    {
        barController = bar.GetComponent<BarController>();
    }

    public void leftButtonDown()
    {
        barController.leftMove = true;
    }

    public void leftButtonUp()
    {
        barController.leftMove = false;
    }

    public void rightButtonDown()
    {
        barController.rightMove = true;
    }

    public void rightButtonUp()
    {
        barController.rightMove = false;
    }
}