using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommetMover : MonoBehaviour
{
	Vector2 speedVec;
	public float speed = 10.0f;

	void Update()
	{
		if (GameController.gameEnd)
		{
			Destroy(this.gameObject);
		}
		else
		{
			speedVec = Vector2.zero;
			speedVec.y -= speed;
			GetComponent<Rigidbody2D>().velocity = speedVec;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Destroy(this.gameObject);

		if (coll.gameObject.tag == "player")
			GameController.gameEnd = true;
	}
}
