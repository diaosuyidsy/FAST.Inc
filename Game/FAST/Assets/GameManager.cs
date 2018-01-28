using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
	public static GameManager GM;

	public GameObject playerOne;
	public GameObject playerTwo;
	public Camera camera_R;
	public Camera camera_L;

	void Awake ()
	{
		if (GM == null) {
			GM = this;
		}
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
