using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
	void OnEnable ()
	{
		transform.Translate (Vector2.right * Time.deltaTime);
	}
}
