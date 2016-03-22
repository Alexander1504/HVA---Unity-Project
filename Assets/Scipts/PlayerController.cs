using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	//Max Speed of the player
	public float mMaxSpeed;

	//Is the player facing right?
	private bool mPlayerIsFacingRight = true;

	//RigidBody of the player
	private Rigidbody2D mPlayerBody2D;

	// Use this for initialization
	void Start ()
	{
		mPlayerBody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{
		float move = Input.GetAxis ("Horizontal");
		mPlayerBody2D.velocity = new Vector2 (move * mMaxSpeed, mPlayerBody2D.velocity.y);

		if (move > 0 && !mPlayerIsFacingRight) {
			Flip ();
		} else if (move < 0 && mPlayerIsFacingRight) {
			Flip ();
		}
	}

	void Flip ()
	{
		mPlayerIsFacingRight = !mPlayerIsFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
