using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
	public bool LeftGameStarted = false;
	public bool RightGameStarted = false;


	public Text Dialogue_Box_Text_Right;
	public Text Dialogue_Box_Text_Left;

	public TextAsset DialogueAsset_R;
	public TextAsset DialogueAsset_L;

	public int rowLimit;

	Queue<string> openingDialogueQ_R;
	Queue<string> openingDialogueQ_L;

	void Start ()
	{
		openingDialogueQ_R = new Queue<string> ();
		openingDialogueQ_L = new Queue<string> ();
		string[] r = DialogueAsset_R.text.Split ("\n" [0]);
		string[] l = DialogueAsset_L.text.Split ("\n" [0]);

		foreach (string sentence in r) {
			openingDialogueQ_R.Enqueue (sentence);
		}
		foreach (string sentence in l) {
			openingDialogueQ_L.Enqueue (sentence);
		}
		StartCoroutine (TypeSentence (openingDialogueQ_R.Dequeue (), true));
		StartCoroutine (TypeSentence (openingDialogueQ_L.Dequeue (), false));
	}

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Space) && !RightGameStarted) {
			StartCoroutine (TypeSentence (openingDialogueQ_R.Dequeue (), true));
			if (openingDialogueQ_R.Count <= 0) {
				Dialogue_Box_Text_Right.gameObject.SetActive (false);
				RightGameStarted = true;
			}
		}

		if (Input.GetKeyUp (KeyCode.LeftShift) && !LeftGameStarted) {
			StartCoroutine (TypeSentence (openingDialogueQ_L.Dequeue (), false));
			if (openingDialogueQ_L.Count <= 0) {
				Dialogue_Box_Text_Left.gameObject.SetActive (false);
				LeftGameStarted = true;
			}
		}
	}


	IEnumerator TypeSentence (string sentence, bool right)
	{
		Text avatar = right ? Dialogue_Box_Text_Right : Dialogue_Box_Text_Left;
		avatar.text = "";
		int wordLength = 0;
		string[] choppedUp = sentence.Split (' ');
		foreach (string chop in choppedUp) {
			avatar.text += chop + " ";
			wordLength += chop.Length + 1;
			if (wordLength >= rowLimit) {
				avatar.text += "\n";
				wordLength = 0;
			}
			yield return new WaitForSeconds (0.1f);
		}
	}
}
