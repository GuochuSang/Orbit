using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriangleRotate : MonoBehaviour {
		public float rotationSpeed;
		private float angle = 0;
	public float beginangle;
		// Use this for initialization
		void Start () {
		angle = beginangle;
		}

		// Update is called once per frame
		void Update () {
		angle += rotationSpeed * Time.deltaTime;
		if (angle > 360)
			angle = 0;

		transform.rotation = Quaternion.Euler (angle, 0, 30);
		}
	}

