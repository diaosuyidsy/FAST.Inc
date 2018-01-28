using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour
{
	public Transform[] MovePoints;
	public float MoveSpeed;
	public bool stopAtLastPoint = false;
	public GameObject pillar;
	Vector3[] pts;
	Vector3 nextTargetPoint;
	int nextPointPointer = 0;
	bool stop = false;


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
		if (stop)
			return;
		
		if (pillar != null)
			extendPillar ();
		
		nextTargetPoint = pts [nextPointPointer];
		Vector3 diff = nextTargetPoint - transform.position;
		diff.Normalize ();

		if (Vector3.Distance (transform.position, nextTargetPoint) >= 0.03f) {
			transform.position += new Vector3 (diff.x, diff.y) * MoveSpeed * Time.deltaTime * 0.7f;
		} else {
			nextPointPointer = (nextPointPointer + 1) % pts.Length;
			// Stop at last point if specificed
			if (stopAtLastPoint && nextPointPointer == 0)
				stop = true;
		}
	}

	void extendPillar ()
	{
		pillar.transform.localScale += new Vector3 (0, Time.deltaTime * 1.15f * ((nextTargetPoint.y - transform.position.y > 0) ? 1f : -1f));
	}
		
}
