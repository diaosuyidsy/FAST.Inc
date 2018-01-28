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

<<<<<<< HEAD
		if (otherAudioPlaying){
=======
		otherAudioPlaying = otherTrigger.GetComponent<AudioSource> ().isPlaying;
		
		if (otherAudioPlaying) {
>>>>>>> fddcf943f1ae7aeb1a8e5c7551c2f458ed1c329b
			return;
		}

		otherAudioPlaying = otherTrigger.GetComponent<AudioSource> ().isPlaying;
			
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			if (!alreadyPlayed) {
				audio.Play ();
				GameManager.GM.TimeTriggered ();
				alreadyPlayed = true;
			}
		}
	}
}
