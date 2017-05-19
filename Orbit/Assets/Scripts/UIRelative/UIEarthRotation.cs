using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEarthRotation : MonoBehaviour {
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localEulerAngles -= new Vector3 (0, rotationSpeed * Time.deltaTime, 0);
	}
}
