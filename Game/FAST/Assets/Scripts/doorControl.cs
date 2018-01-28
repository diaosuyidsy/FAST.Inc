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

	void Start ()
	{
		CodeEntered = new bool[maxCodeNum];
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
		}
	}
}
