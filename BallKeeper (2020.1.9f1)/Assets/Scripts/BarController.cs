using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    Vector3 moveVelocity;
    public float moveSpeed = 300.0f;

    public bool leftMove = false;
    public bool rightMove = false;

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameEnd)
        {
            if (leftMove)
            {
                moveVelocity = new Vector3(-0.10f, 0, 0);
                transform.position += moveVelocity * moveSpeed * Time.deltaTime;
            }
            if (rightMove)
            {
                moveVelocity = new Vector3(+0.10f, 0, 0);
                transform.position += moveVelocity * moveSpeed * Time.deltaTime;
            }
        }
    }
}
