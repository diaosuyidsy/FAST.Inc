using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTriggerScript : MonoBehaviour {

	AudioSource audio;
	public GameObject otherTrigger;

	bool otherAudioPlaying = false;
	bool alreadyPlayed = false;

	void Start(){
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (otherAudioPlaying){
			return;
		}

		otherAudioPlaying = otherTrigger.GetComponent<AudioSource> ().isPlaying;
			
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			if (!alreadyPlayed) {
				audio.Play ();
				alreadyPlayed = true;
			}
		}
	}
}
