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
	public GameObject linkedDoor;
	public GameObject linkedFloor;
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
						// If it got a linked door, open up linked doof
						if (linkedDoor != null) {
							for (int i = 0; i < linkedDoor.GetComponent<doorControl> ().maxCodeNum; i++) {
								linkedDoor.GetComponent<doorControl> ().codeEnterCorrectly (i + 1);
							}
						}
						if (linkedFloor != null) {
							linkedFloor.SetActive (false);
						}
						GetComponent<BoxCollider2D> ().enabled = false;
					} else
						Prompt.text = "DEAD YOU ARE";
					// Disable the canType so player cannot repeatly enter numbers
					canType = false;
				}
			}
		}
	}

	void OnCollisionStay2D (Collision2D coll)
	{
		if (coll.collider.tag == "PlayerOne" || coll.collider.tag == "PlayerTwo") {
			Prompt.gameObject.SetActive (true);
			canType = true;
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.collider.tag == "PlayerOne" || coll.collider.tag == "PlayerTwo") {
			Prompt.gameObject.SetActive (false);
			canType = false;
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
