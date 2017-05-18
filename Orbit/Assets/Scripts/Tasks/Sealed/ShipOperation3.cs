using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipOperation3:Operation {
	public Orbitor orbitor;
	public GameObject GM, ER;
	public override bool OperationCheck ()
	{
		orbitor = GM.GetComponent <Orbitor> ();
		if (orbitor.Father == ER)
			return true;
		else
			return false;
	}

}
