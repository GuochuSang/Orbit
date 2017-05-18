using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : CelestialBody{
	public float rocketPower;
	public float speedLimit;
	public GameObject Arrow;
	public GameObject flare;
	private Vector2 Force;

	public override void Start () {
		base.Start ();
	}

	public override void Update(){
		base.Update ();
	}

	public override void FixedUpdate () {
		#region SetArrow
		if(thisRig2D.velocity.x>0)
			Arrow.transform.rotation=Quaternion.Euler (0,0,-Vector2.Angle (new Vector2(0,1),GetComponent <Rigidbody2D>().velocity));
		if(thisRig2D.velocity.x<=0)
			Arrow.transform.rotation=Quaternion.Euler (0,0,Vector2.Angle (new Vector2(0,1),GetComponent <Rigidbody2D>().velocity));
		Arrow.transform.position=transform.position;
		#endregion
		#region SpeedLimit
		if (thisRig2D.velocity.magnitude >= speedLimit)
			thisRig2D.velocity = GetComponent <Rigidbody2D> ().velocity.normalized * speedLimit;
		#endregion
		#region PowerAndFlare
		Force =(new Vector2(Input.mousePosition.x,Input.mousePosition.y)-new Vector2 (Camera.main.WorldToScreenPoint (transform.position).x,Camera.main.WorldToScreenPoint (transform.position).y)).normalized*rocketPower;
		if(Input.GetMouseButton (0))
		{
			flare.SetActive (true);
			GetComponent <Rigidbody2D>().AddForce (Force);
		}else
			flare.SetActive (false);
		
		transform.rotation=Quaternion.Euler (0,0,Mathf.Sign(-Force.x)*Vector2.Angle (new Vector2(0,1),Force));
		#endregion
		base.FixedUpdate ();
	}
}
