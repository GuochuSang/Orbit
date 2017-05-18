using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class CameraFollow : MonoBehaviour {
	public GameObject target,ship,Manager;
	private Orbitor orbitor;
	public float moveSpeed;
	public GameObject Arrow;
	public float size = 0.05f;
	public float scrollSpeed;
	public float maxScreen, minScreen;
	private Camera cam;

	public void Follow()
	{
		//float d = Vector3.Distance (transform.position, target.transform.position + new Vector3 (0, 0, -100));
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position+new Vector3(0,0,-100), moveSpeed* Time.deltaTime);
		if (cam.orthographicSize < minScreen+3)
			cam.orthographicSize =minScreen+3;
		if (cam.orthographicSize > maxScreen-3)
			cam.orthographicSize =maxScreen-3;
		float orth=cam.orthographicSize;
		cam.orthographicSize=Mathf.Lerp (orth,(-(scrollSpeed/2)*Mathf.Sin (((3.14f)/(maxScreen/2-minScreen))*orth+3.14f*(0.5f-(minScreen/(maxScreen/2-minScreen))))+(scrollSpeed/2))*Input.GetAxis ("Mouse ScrollWheel")+orth,0.5f);
		Arrow.transform.localScale = new Vector3(size * cam.orthographicSize,size * cam.orthographicSize,1);
	}

	void Start () {
		orbitor =Manager.gameObject.GetComponent <Orbitor> ();
		cam = this.GetComponent <Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (orbitor.Father != null) {
			target = orbitor.Father;
		} else {
			target = ship;
		}
	}

	void FixedUpdate(){
		Follow ();
	}
}
