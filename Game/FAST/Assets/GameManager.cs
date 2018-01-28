using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager GM;

	public GameObject playerOne;
	public GameObject playerTwo;
	public Camera camera_R;
	public Camera camera_L;
	public Text CountDownLeft;
	public Text CountDownRight;

	int timer = 60;
	bool startTimer = false;

	void Awake ()
	{
		if (GM == null) {
			GM = this;
		}
	}

	void Start ()
	{
//		TimeTriggered ();
	}

	public void OnDeath ()
	{
		Animator animOne = playerOne.GetComponentInChildren <Animator> ();
		Animator animTwo = playerTwo.GetComponentInChildren <Animator> ();

		foreach (AnimatorControllerParameter p in animOne.parameters) {
			animOne.SetBool (p.name, false);
		}
		foreach (AnimatorControllerParameter p in animTwo.parameters) {
			animTwo.SetBool (p.name, false);
		}

		animOne.Play ("BoyDeath");
		animTwo.Play ("GirlDeath");
		StartCoroutine (delayBlackOut (1f));
	}



	public void TimeTriggered ()
	{
		if (startTimer)
			return;
		startTimer = true;
		StartCoroutine (tt ());
	}

	IEnumerator tt ()
	{
		while (timer > 0) {
			timer--;
			CountDownLeft.text = timer.ToString ();
			CountDownRight.text = timer.ToString ();
			yield return new WaitForSeconds (1f);
		}
		if (timer <= 0) {
			OnDeath ();
		}
	}

	IEnumerator delayBlackOut (float time)
	{
		yield return new WaitForSeconds (time);
		float timer = 1f;
		while (timer >= 0f) {
			timer -= Time.deltaTime;
			camera_R.orthographicSize -= Time.deltaTime;
			camera_L.orthographicSize -= Time.deltaTime;
			yield return null;
		}
	}

}
