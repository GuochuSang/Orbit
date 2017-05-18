using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipOperation1 : Operation {
	public GameObject ship;
	public override bool OperationCheck ()
	{
		return ship.GetComponent <SpaceShip> ().flare.activeInHierarchy;
	}
}
