using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
	private bool triggered = false;

	void OnEnable ()
	{
		triggered = true;
	}

	void Update ()
	{
		if (triggered) {
			transform.Translate (Vector2.right * Time.deltaTime * 10);
		}
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			GameManager.GM.OnDeath ();
		}
	}
}
