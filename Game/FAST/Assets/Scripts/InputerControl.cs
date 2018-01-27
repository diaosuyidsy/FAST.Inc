﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputerControl : MonoBehaviour
{
	public Text InputterText;
	public int CorrectNum = 3;
	public int serialNumber;
	public GameObject InputObjectFor;
	private bool canType = false;
	private bool solved = false;

	void Update ()
	{
		if (canType) {
			string answer = "";
			foreach (char c in Input.inputString) {
				
				answer = c.ToString ();
				Debug.Log (answer);
				// If player got correct Num, display it
				if (answer == CorrectNum.ToString ()) {
					Debug.Log (answer);
					InputterText.text = answer.ToString ();
					// Then tell the door the player got it
					InputObjectFor.GetComponent<doorControl> ().codeEnterCorrectly (serialNumber);
					// Disable the canType so player cannot repeatly enter numbers
					canType = false;
					// Marked it as solved
					solved = true;
				}
			}
		}
	}

	void OnTriggerStay2D (Collider2D coll)
	{
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			InputterText.gameObject.SetActive (true);
			canType = true;
		}
	}

	void OnTriggerExit2D (Collider2D coll)
	{
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			if (!solved)
				InputterText.gameObject.SetActive (false);
			canType = false;
		}
	}
}
