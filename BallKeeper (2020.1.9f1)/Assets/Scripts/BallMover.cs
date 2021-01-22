using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
	Vector2 speedVec;
	float Xspeed;
	float Yspeed;
	public float moveSpeed = 700.0f;
	void Start()
	{
		Xspeed = moveSpeed;
		Yspeed = moveSpeed;
	}

	void Update()
	{
		speedVec = Vector2.zero;

		speedVec.x += Xspeed * Time.deltaTime;
		speedVec.y += Yspeed * Time.deltaTime;

		GetComponent<Rigidbody2D>().velocity = speedVec;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "UWall")
		{
			Yspeed = changeSpeed();
			if (Yspeed > 0.0f)
				Yspeed *= -1;
		}
		else if (coll.gameObject.tag == "DWall")
		{
			Yspeed = changeSpeed();
			if (Yspeed < 0.0f)
				Yspeed *= -1;
		}
		else if (coll.gameObject.tag == "LWall")
		{
			Xspeed = changeSpeed();
			if (Xspeed < 0.0f)
				Xspeed *= -1;
		}
		else if (coll.gameObject.tag == "RWall")
		{
			Xspeed = changeSpeed();
			if (Xspeed > 0.0f)
				Xspeed *= -1;
		}
		else if (coll.gameObject.tag == "floor")
		{
			Destroy(this.gameObject);
			GameController.gameEnd = true;
		}
	}

	int changeSpeed()
	{
		return randomNumber((int)moveSpeed - 100, (int)moveSpeed + 100);
	}

	int randomNumber(int min, int max)
	{
		return (int)UnityEngine.Random.Range(min, max + 1);
	}
}
