using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnCollide : MonoBehaviour
{
	
	public GameObject ShouldShow;

	void OnTriggerStay2D (Collider2D coll)
	{
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			ShouldShow.SetActive (true);
		}
	}

	void OnTriggerExit2D (Collider2D coll)
	{
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			ShouldShow.SetActive (false);
		}
	}
}
