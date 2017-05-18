using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityRelativeColor : MonoBehaviour {
	private SpriteRenderer sr;
	private Rigidbody2D r;
	public SpaceShip sh;

	void Start () {
		sr = GetComponent <SpriteRenderer> ();
		r = sh.GetComponent <Rigidbody2D> ();
	}

	void Update () {
		sr.color=new Color(r.velocity.magnitude/sh.speedLimit,1-r.velocity.magnitude/sh.speedLimit,0);
	}
}
