﻿using System.Collections;
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
		if (coll.tag == "PlayerOne")
			GameManager.GM.OneRespawnPlace = gameObject;
		if (coll.tag == "PlayerTwo")
			GameManager.GM.TwoRespawnPlace = gameObject;

		otherAudioPlaying = otherTrigger.GetComponent<AudioSource> ().isPlaying;
		
		if (otherAudioPlaying) {
			return;
		}
			
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			if (!alreadyPlayed) {

				if (DialogueControl.DC.GameStarted) {
					GameManager.GM.TimeTriggered ();
					audio.Play ();
				}
				alreadyPlayed = true;
			}
		}
	}
}
