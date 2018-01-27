using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHitScript : MonoBehaviour {

	AudioSource sound; 

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "PlayerOne" || coll.gameObject.tag == "PlayerTwo") {
			sound.Play ();
		}
	}
}
