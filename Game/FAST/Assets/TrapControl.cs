using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
	public GameObject TriggerTrap;
	public GameObject SaveTrap;
	public GameObject Trap;

	void Start ()
	{
		SaveTrap.SetActive (false);
	}

	public void OnTriggerTrap ()
	{
		// Activate the savetrap
		SaveTrap.SetActive (true);
		// Activate dangerous net
		Trap.SetActive (true);
	}

	public void OnSaveTrap ()
	{
		// Disable Everything
		TriggerTrap.SetActive (false);
		SaveTrap.SetActive (false);
		Trap.SetActive (false);
	}
}
