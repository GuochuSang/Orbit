using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole: CelestialBody {

	public float rotateSpeed = 40f;
	public Transform blackCenter;
	public List<Transform> BlackHoleCircle=new List<Transform>();

	private void FollowCenter()
	{foreach (Transform circle in BlackHoleCircle) {
			circle.position = blackCenter.position;
			circle.Rotate (new Vector3 (0, 0, rotateSpeed * Time.deltaTime));
		}
	}

	public override void Start ()
	{
		base.Start ();
	}

	public override  void Update () 
	{
		FollowCenter ();
		base.Update ();
	}

	public override void FixedUpdate(){
		base.FixedUpdate ();
	}
}
