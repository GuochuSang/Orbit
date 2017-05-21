using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipOperation5 : Operation {
	
	#region Declare
	public GameObject GM,ship,sun;
	private bool step1, step2;
	private Orbitor orbitor;
	#endregion

	public override bool OperationCheck ()
	{
		if (Vector3.Distance (ship.transform.position, sun.transform.position) < 100f)
			step1 = true;
		else
			step2 = false;
		orbitor = GM.GetComponent <Orbitor> ();
		if (orbitor.Father != null && orbitor.Father == sun)
			step2 = true;
		else
			step2 = false;
		if (step1 && step2)
			return true;
		else
			return false;
	}
}
