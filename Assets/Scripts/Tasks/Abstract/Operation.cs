using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Operation : BasicUIMessage {

	public override bool Completed ()
	{
		if (OperationCheck()&&taskstate==state.OnGoing) {
			beforePlayedDelay = 0;
			beforePlayedExist = 0;
			return base.Completed ();
		}
		else
			return false;
	}
	public virtual bool OperationCheck()
	{
		return true;
}
}
