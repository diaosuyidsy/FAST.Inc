using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTriggerScript : MonoBehaviour
{

	AudioSource audio;
	public GameObject otherTrigger;

	bool otherAudioPlaying = false;
	bool alreadyPlayed = false;

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D coll)
	{

		otherAudioPlaying = otherTrigger.GetComponent<AudioSource> ().isPlaying;
		
		if (otherAudioPlaying) {
			return;
		}
			
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			if (!alreadyPlayed) {
				audio.Play ();
				GameManager.GM.TimeTriggered ();
				alreadyPlayed = true;
			}
		}
	}
}
