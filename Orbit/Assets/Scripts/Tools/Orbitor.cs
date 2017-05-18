using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
// Do The Orbit
public class Orbitor : MonoBehaviour {
	#region Declare
	public GameObject player;
	public GameObject Father;
	public CelestialBody celestialbody;
	public Text message;
	#endregion

	public void GetFatherAndCancleAndSendMessage(){
		if (Input.GetButtonDown ("Orbit")) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); 
			if(hit.collider != null)
			{ 
				Father = hit.collider.gameObject;
				if (Father==player)
					Father = null;
				if (Father != null) {
					Vector2 velocity = celestialbody.gameObject.GetComponent <Rigidbody2D> ().velocity - Father.GetComponent <Rigidbody2D> ().velocity;
					float dir;
					dir=Vector3.Cross(velocity,player.transform.position-Father.transform.position).z;
					if (dir>0)
						celestialbody.orbitDirection = Enums.OrbitDirection.clockwise;
					else
						celestialbody.orbitDirection = Enums.OrbitDirection.anticlockwise;
					if (celestialbody.orbitTarget != null && celestialbody.orbitTarget == Father)
						celestialbody.orbit = !celestialbody.orbit;
					else
						celestialbody.orbit = true;
				}
				celestialbody.isSun = false;
				celestialbody.orbitTarget = Father;
			}
		}
		if (celestialbody != null) {
			if (celestialbody.orbitTarget == null || celestialbody.orbit == false)
				message.text = "Automatic Orbiting:None\n" + "Velocity:" + celestialbody.thisRig2D.velocity.magnitude.ToString ();
			else
				message.text = "Automatic Orbiting:" + celestialbody.orbitTarget.name + "\nVelocity:" + celestialbody.thisRig2D.velocity.magnitude.ToString ();
		
			if (celestialbody.orbit == false)
				Father = null;
		}
	}

	void Start () {
		player=GameObject.Find ("ship");
		if (player != null) {
			celestialbody = player.GetComponent <CelestialBody> ();
			message = GameObject.Find ("ShipMessage").GetComponent <Text> ();
		}
	}

	void Update () {
		GetFatherAndCancleAndSendMessage ();
	}
}
