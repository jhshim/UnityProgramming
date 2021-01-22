using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public static char latestDirection;

	public GameObject bullet;
	Vector2 speedVec;
	Animator animator;

	float speed = 5;

	void Start()
	{
		animator = GetComponent<Animator> ();
		PlayerController.latestDirection = 'L';
	}

	void Update ()
	{
		speedVec = Vector2.zero;

		animator.SetBool ("Left", false);
		animator.SetBool ("Right", false);
		animator.SetBool ("Shoot_left", false);
		animator.SetBool ("Shoot_right", false);

		if (Input.GetKey (KeyCode.RightArrow)) {
			animator.SetBool ("Right", true);
			speedVec.x += speed;
			PlayerController.latestDirection = 'R';
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			animator.SetBool ("Left", true);
			speedVec.x -= speed;
			PlayerController.latestDirection = 'L';
		}

		if (Input.GetKey (KeyCode.Z)) {
			if (PlayerController.latestDirection == 'L')
				animator.SetBool ("Shoot_left", true);
			else if (PlayerController.latestDirection == 'R')
				animator.SetBool ("Shoot_right", true);
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			float bulletX = 0.0f;

			if (PlayerController.latestDirection == 'L')
				bulletX = this.transform.position.x - 1.5f;
			else if (PlayerController.latestDirection == 'R')
				bulletX = this.transform.position.x + 1.5f;

			StartCoroutine ("createBullet");
		}

		if (Input.GetKeyUp (KeyCode.Z)) {
			StopCoroutine ("createBullet");
		}

		GetComponent<Rigidbody2D> ().velocity = speedVec;
	}

	IEnumerator createBullet(){
		float bulletX = 0.0f;

		if (latestDirection == 'L')
			bulletX = this.transform.position.x - 1.5f;
		else if (latestDirection == 'R')
			bulletX = this.transform.position.x + 1.5f;

		GameObject b = (GameObject)
			Instantiate (bullet, new Vector3 (bulletX, this.transform.position.y + 0.5f, 0.0f), Quaternion.identity);

		yield return new WaitForSeconds (0.1f);
		StartCoroutine ("createBullet");
	}
}