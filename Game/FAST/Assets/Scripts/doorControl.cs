using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class doorControl : MonoBehaviour
{
	public int maxCodeNum = 3;
	public GameObject timerMusic;
	public GameObject otherDoor;

	bool[] CodeEntered;
	int codeEntered = 0;
	bool startLifting = false;
	float liftTimer = 2f;
	AudioSource audio;
	BoxCollider2D coll;
	bool finishedOnePuzzle = false;
	bool finishedTwoPuzzle = false;

	int musicBlockNum = 5;

	int[] playerTwoMusicCode;
	int[] playerTwoEnteredCode;

	void Start ()
	{
		CodeEntered = new bool[maxCodeNum];


		playerTwoMusicCode = new int[musicBlockNum];
		playerTwoMusicCode [0] = 1;
		playerTwoMusicCode [1] = 3;
		playerTwoMusicCode [2] = 4;
		playerTwoMusicCode [3] = 2;
		playerTwoMusicCode [4] = 5;

		playerTwoEnteredCode = new int[musicBlockNum];

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
			OpenDoor ();
		}
	}

	public void checkMusicCode(int n, int codeNum){

		Debug.Log (codeNum);

		if (n > 5) {
			for (int j = 0; j < 5; j++) {
				playerTwoEnteredCode [j] = 0;
			}
		}

		if (n == -1 && codeNum == -1) {
			return;
		}
			
		playerTwoEnteredCode [n - 1] = codeNum;
		bool notEnteredIf = true;

		Debug.Log (playerTwoEnteredCode [n-1]);

		for (int j = 0; j < 5; j++) {
			if (playerTwoEnteredCode [j] != playerTwoMusicCode [j]) {
				notEnteredIf = false;
			}
		}
		finishedTwoPuzzle = notEnteredIf;
			
		if (finishedTwoPuzzle) {
			Debug.Log ("In the last if statement");
			OpenDoor ();
		}
	}

	void OpenDoor(){

		if (otherDoor == null) {
			Debug.Log ("No door found");
			return;
		}

		Debug.Log ("Open SESAME");
		GetComponent<Animator> ().SetBool ("DoorOpen", true);
		otherDoor.GetComponent<Animator> ().SetBool ("DoorOpen", true);
		audio.Play ();
		coll.enabled = !coll.enabled;
		timerMusic.GetComponent<AudioSource> ().Stop ();
	}
}
