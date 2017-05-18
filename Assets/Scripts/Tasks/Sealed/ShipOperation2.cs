using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class ShipOperation2 : Operation {
	public override bool OperationCheck ()
	{
		if (Input.GetAxis ("Mouse ScrollWheel") != 0)
			return true;
		else
			return false;
	}
	public override void CompleteDo ()
	{
		base.CompleteDo ();
	}
}
