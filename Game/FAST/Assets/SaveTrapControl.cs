using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrapControl : MonoBehaviour
{

	public GameObject TrapControl;

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			TrapControl.GetComponent<TrapControl> ().OnSaveTrap ();
		}
	}
}
