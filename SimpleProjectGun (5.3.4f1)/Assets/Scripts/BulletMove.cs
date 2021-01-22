using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour
{
	Vector2 speedVec;
	float speed;

	void Start()
	{
		speed = 60.0f;

		if(PlayerController.latestDirection == 'L')
			speed *= -1.0f;
	}

	void Update ()
	{
		speedVec = Vector2.zero;
		speedVec.x += speed;

		GetComponent<Rigidbody2D> ().velocity = speedVec;
	}

	void OnCollisionStay2D(Collision2D coll)
	{
			Destroy (this.gameObject);
	}
}