using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipOperation4 : Operation {
	public GameObject GM,Jupiter;
	private SignedPosition sp;
	public override bool OperationCheck ()
	{
		sp=GM.GetComponent <SignedPosition>();
		if (sp.signedPositions [sp.activePoint].fcelestialBody == Jupiter)
			return true;
		else
			return false;
	}
}
