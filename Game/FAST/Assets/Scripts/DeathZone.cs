using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.collider.tag == "PlayerOne" || coll.collider.tag == "PlayerTwo") {
			GameManager.GM.OnDeath ();
		} else {
			Destroy (coll.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		Destroy (coll.gameObject);
	}
}
