using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enums{
	
	public enum OrbitDirection
	{
		clockwise=0,
		anticlockwise=1,
	}

	public enum MassScaleController
	{
		Mass2Scale=0,
		Scale2Mass=1,
	}
}

public class CelestialBody : MonoBehaviour {

    [Header("Gravity Controller")]
	#region GravityController
	static List<GameObject> Celestiabodies = new List<GameObject>();
	public bool naturalMass;
	public GameObject Manager;
	public Enums.MassScaleController massScaleController;
	public bool isSun;
	public bool isShip;
	public float density;
	protected float G;
	public Rigidbody2D thisRig2D;
	public int GiveGravity(GameObject obj)
	{
		if (obj!=null&&obj != this.gameObject) {
			Rigidbody2D objRig2D = obj.GetComponent <Rigidbody2D> ();
			float r = Vector3.Distance (transform.position, obj.transform.position);
			CelestialBody objCele = obj.GetComponent<CelestialBody> ();
			if (!objCele.isSun) {
				#region AddForce
				Vector2 force = -((obj.transform.position) - (this.transform.position)).normalized
				              * thisRig2D.mass *
				              objRig2D.mass * (1 / (r * r)) * G;
				#endregion
				objRig2D.AddForceAtPosition (force, transform.position);
			}
		}
		return 1;
	}
	#endregion

    [Header("Velocity Controller")]
	#region VelocityController
	public Vector3 customVelocity;
	public bool randomVelocity;
	public bool enableVelocitySet;
	public float randomRange;
    	public Vector3 GetVelocityFromEditor(){
		if (randomVelocity) {
			return (new Vector2 (UnityEngine.Random.Range (-randomRange, randomRange), UnityEngine.Random.Range (-randomRange, randomRange)));
		} else if (!randomVelocity) {
			return customVelocity;
		} else
			return Vector3.zero;
	}
   	public bool SetVelocity(Vector3 velocity){
		if (velocity != null) {
			thisRig2D.velocity = velocity;
			return true;
		} else {
			return false;
		}
	}
	#endregion

    [Header("Orbit Controller")]
	#region OrbitController
	public Enums.OrbitDirection orbitDirection;
	public GameObject orbitTarget;
	public bool orbit;
	[HideInInspector]
	public Vector2 orbitVelocity;
    	public int Orbit(GameObject obj){
		Rigidbody2D objRig2D = obj.GetComponent<Rigidbody2D> ();
		int sign=1;
		if (orbitDirection == Enums.OrbitDirection.clockwise)
			sign = 1;
		else
			sign = -1;
		float r = Vector2.Distance (transform.position,
			                obj.transform.position);
		orbitVelocity =
            sign *
		(Vector3.Cross (transform.position - obj.transform.position,
			new Vector3 (0, 0, 1)).normalized * Mathf.Sqrt (G * objRig2D.mass / r));
		if(orbitVelocity!=null&&objRig2D.velocity!=null)
		thisRig2D.velocity = orbitVelocity + objRig2D.velocity;
		return 1;
	}
	#endregion

	[HideInInspector]
	#region GetName
	public bool getNamed;
	#endregion

	public string GetName()
	{
		if (orbitTarget != null && orbit&&!getNamed)
			name = orbitTarget.GetComponent<CelestialBody>().GetName()+"_"+name;
		getNamed = true;
		return name;
	}

	protected void DoStart(){
		Manager = GameObject.Find ("Manager");
		GetName ();
		thisRig2D = GetComponent <Rigidbody2D> ();
		if(!isShip)
		Manager.GetComponent <SignedPosition>().BaseAdd (name,Vector3.zero,true,gameObject);
		G = GameManager.Instance.gravitionalConstant;
		Celestiabodies.Add (this.gameObject);
		if (enableVelocitySet)
			SetVelocity (GetVelocityFromEditor ());
	}

	protected void DoUpdate(){
		if (naturalMass) {
			DecideMassAndScale ();
		}
	}

	protected void DoFixedUpdate(){
		foreach (GameObject celestial in Celestiabodies) {
			GiveGravity(celestial);
		}
		if (orbit)
			Orbit (orbitTarget);
	}

	protected void DecideMassAndScale()
	{
		if (massScaleController == Enums.MassScaleController.Scale2Mass) {
			thisRig2D.mass = 4.1887f * density * transform.localScale.x
				* transform.localScale.y
				* transform.localScale.z;
		} else {
			float r3 = 0.2387f * thisRig2D.mass / density;
			float r = Mathf.Pow (r3, 3);
			transform.localScale = new Vector3 (r,r,r);
		}
	}

	public virtual void Start () {
		DoStart ();
	}

	public virtual void Update(){
		DoUpdate ();
	}

	public virtual void FixedUpdate () {
		DoFixedUpdate ();
	}
}
