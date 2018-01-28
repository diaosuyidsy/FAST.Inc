using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

	public GameObject Prompt;

	void OnCollisionStay2D (Collision2D coll)
	{
		if (coll.collider.tag == "PlayerOne" || coll.collider.tag == "PlayerTwo") {
			Prompt.gameObject.SetActive (true);
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.collider.tag == "PlayerOne" || coll.collider.tag == "PlayerTwo") {
			Prompt.gameObject.SetActive (false);
		}
	}
}
