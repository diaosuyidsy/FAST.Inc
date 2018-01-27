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
		CodeEntered [num - 1] = true;
		if (CodeEntered.All (code => code)) {
			startLifting = true;
		}
	}

	void Update ()
	{
		if (startLifting) {
			liftTimer -= Time.fixedDeltaTime;
			if (liftTimer <= 0f) {
				startLifting = false;
				liftTimer = 1f;
			}
			transform.Translate (Vector2.up * Time.deltaTime);
		}
	}
}
