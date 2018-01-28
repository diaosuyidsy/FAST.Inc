using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputerControl : MonoBehaviour
{
	public Text InputterText;
	public int CorrectNum = 3;
	public int serialNumber;
	public GameObject InputObjectFor;
	public GameObject InputObjectForTwo;
	private bool canType = false;
	private bool solved = false;

	void Update ()
	{
		if (canType) {
			string answer = "";
			foreach (char c in Input.inputString) {
				bool ANumber = false;
				for (int i = 0; i < 10; i++) {
					if (i.ToString () == c.ToString ()) {
						ANumber = true;
					}
				}
				if (!ANumber)
					return;
				answer = c.ToString ();
				Debug.Log ("Answer entered: " + answer);
				// If player got correct Num, display it
				if (answer == CorrectNum.ToString ()) {
					Debug.Log ("Is correct: " + answer);
					InputterText.text = answer.ToString ();
					// Then tell the door the player got it
					InputObjectFor.GetComponent<doorControl> ().codeEnterCorrectly (serialNumber);
					if (InputObjectForTwo != null) {
						InputObjectForTwo.GetComponent<doorControl> ().codeEnterCorrectly (serialNumber);
					}
					// Disable the canType so player cannot repeatly enter numbers
					canType = false;
					// Marked it as solved
					solved = true;
				} else{
					GameManager.GM.OnDeath ();
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
