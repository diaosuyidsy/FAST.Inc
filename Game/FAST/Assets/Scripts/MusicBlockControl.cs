using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBlockControl : MonoBehaviour {

	public int serialNum = 1;
	public int codeNum = 1;
	public GameObject inputObject; //Drag in inspector. 
	public bool playerOne = true;

	AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> (); 
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "PlayerOne" || coll.gameObject.tag == "PlayerTwo") {
			sound.Play ();

			inputObject.GetComponent<doorControl> ().checkMusicCode (serialNum,codeNum);
		}
	}
}
