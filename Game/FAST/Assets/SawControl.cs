using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControl : MonoBehaviour
{
	
	public Transform[] MovePoints;
	public float MoveSpeed;
	Vector3[] pts;
	Vector3 nextTargetPoint;
	int nextPointPointer = 0;


	void Start ()
	{
		// Initialize move points
		pts = new Vector3[MovePoints.Length];
		for (int i = 0; i < MovePoints.Length; i++) {
			pts [i] = new Vector3 (MovePoints [i].position.x, MovePoints [i].position.y, MovePoints [i].position.z);
		}
	}

	void Update ()
	{
		nextTargetPoint = pts [nextPointPointer];
		Vector3 diff = nextTargetPoint - transform.position;
		diff.Normalize ();

		float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);

		if (Vector3.Distance (transform.position, nextTargetPoint) >= 0.03f) {
			transform.position += transform.up * MoveSpeed * Time.deltaTime * 0.7f;
		} else {
			nextPointPointer = (nextPointPointer + 1) % pts.Length;
		}
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.tag == "PlayerOne" || coll.tag == "PlayerTwo") {
			Debug.Log ("Player Die");
		}
	}
}
