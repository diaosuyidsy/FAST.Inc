using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectDoorControl : MonoBehaviour
{
	public Text Prompt;
	public bool correctDoor;
	public string InteractStr = "e";
	bool canType;

	void Update ()
	{
		if (canType) {
			string answer = "";
			foreach (char c in Input.inputString) {

				answer = c.ToString ();
				Debug.Log (answer);
				// If player got correct Num, display it
				if (answer == InteractStr) {
					if (correctDoor) {
						Prompt.text = "You are correct";
						GetComponent<Animator> ().SetBool ("DoorOpen", true);
					} else
						Prompt.text = "DEAD YOU ARE";
					// Disable the canType so player cannot repeatly enter numbers
					canType = false;
				}
			}
		}
	}

	void OnTriggerStay2D (Collider2D coll)
	{
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			Prompt.gameObject.SetActive (true);
			canType = true;
		}
	}

	void OnTriggerExit2D (Collider2D coll)
	{
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			Prompt.gameObject.SetActive (false);
			canType = false;
		}
	}
}
