using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class doorControl : MonoBehaviour
{
	public int maxCodeNum = 3;
	bool[] CodeEntered;
	int codeEntered = 0;
	bool startLifting = false;
	float liftTimer = 2f;
	AudioSource audio;
	BoxCollider2D coll;

	void Start ()
	{
		CodeEntered = new bool[maxCodeNum];
		audio = GetComponent<AudioSource> ();
		coll = GetComponent<BoxCollider2D> ();
	}

	public void codeEnterCorrectly (int num)
	{
		if (num < 0) {
			//TODO: Death here.
			return;
		}
		Debug.Log ("Code Entered Correctly");
		CodeEntered [num - 1] = true;
		Debug.Log (CodeEntered.All (code => code));
		if (CodeEntered.All (code => code)) {
			Debug.Log ("Open SESAME");
			GetComponent<Animator> ().SetBool ("DoorOpen", true);
			audio.Play ();
			coll.enabled = !coll.enabled;
		}
	}
}
