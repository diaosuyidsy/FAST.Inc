using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed = 20.0f;
	public float jumpForce = 8.0f;
	public bool isOnGround = true;
	public bool playerOne = true;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public Animator anim;

	bool facingRight = true;
	float moveHorizontal = 0f;
	float moveVertical = 0f;

	float gravity = 9.81f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponentInChildren<Animator> ();

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (GameManager.GM.ActionLocked)
			return;
		if (!DialogueControl.DC.GameStarted)
			return;
		Movement ();
	}

	void Movement ()
	{
		moveVertical = rb.velocity.y;
		moveVertical = Jump (moveVertical);

		moveHorizontal = playerOne ? Input.GetAxisRaw ("HorizontalOne") : Input.GetAxisRaw ("HorizontalTwo");

		//check if player is standing on ground
		isOnGround = Physics2D.Linecast (transform.position, groundCheck.position, whatIsGround) ||
		Physics2D.Linecast (transform.position + new Vector3 (0.5f, 0, transform.position.z), groundCheck.position + new Vector3 (0.5f, 0, groundCheck.position.z), whatIsGround) ||
		Physics2D.Linecast (transform.position - new Vector3 (0.5f, 0, transform.position.z), groundCheck.position - new Vector3 (0.5f, 0, groundCheck.position.z), whatIsGround);

		rb.velocity = new Vector2 (moveHorizontal * speed, moveVertical);

		if (moveHorizontal > 0 && !facingRight) {
			FlipCharacter ();
		} else if (moveHorizontal < 0 && facingRight) {
			FlipCharacter ();
		}

		Animations (moveHorizontal, moveVertical);
	}

	float Jump (float moveVertical)
	{
		if ((Input.GetKeyDown (KeyCode.LeftShift) && playerOne) || (Input.GetKeyDown (KeyCode.Space) && !playerOne)) {
			
			if (isOnGround) {
				moveVertical = 0f;
				rb.AddForce (new Vector2 (0, jumpForce));
			} 
		} 
	
		return moveVertical;
	}

	void Animations (float moveHorizontal, float moveVertical)
	{
		bool oneWalking = false;
		bool twoWalking = false;
		bool oneJumping = false;
		bool twoJumping = false;
		bool oneIdle = true;
		bool twoIdle = true;

		if (playerOne) {
			if (moveHorizontal != 0f) {
				oneWalking = true;
				oneIdle = false;
			} 
			if (moveVertical > 0f) {
				oneJumping = true;
				oneIdle = false;
			} 
			if (moveVertical > 0f && moveHorizontal != 0f) {
				oneJumping = true;
				oneWalking = false;
			}
			anim.SetBool ("oneIsIdle", oneIdle);
			anim.SetBool ("oneIsWalking", oneWalking);
			anim.SetBool ("oneIsJumping", oneJumping);
		} else if (!playerOne) {
			if (moveHorizontal != 0f) {
				twoWalking = true;
				twoIdle = false;
			} 
			if (moveVertical > 0f) {
				twoJumping = true;
				twoIdle = false;
			}
			if (moveVertical > 0f && moveHorizontal != 0f) {
				twoJumping = true;
				twoWalking = false;
			}
			anim.SetBool ("twoIsWalking", twoWalking);
			anim.SetBool ("twoIsJumping", twoJumping);
			anim.SetBool ("twoIsIdle", twoIdle);
		}
	}

	void FlipCharacter ()
	{

		//Changes bool value of looking right to right direction.
		facingRight = !facingRight;

		//Rotates 180 degrees.
		transform.Rotate (0, 180, 0);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.collider.tag == "MovingPlatform") {
			transform.parent = coll.transform;
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.collider.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}
}
