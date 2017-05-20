using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PathPoint{
	public GameObject fcelestialBody;
	public bool follow;
	public string name;
	public Vector3 position;

	public PathPoint(string myname,Vector3 myPosition,bool myfollow,GameObject myGameobject)
	{
		fcelestialBody = myGameobject;
		follow =myfollow;
		name = myname;
		position = myPosition;
	}
}
public class SignedPosition : MonoBehaviour {
	
	public List<PathPoint> signedPositions=new List<PathPoint>();
	public GameObject ship;
	public GameObject PathArrow;
	public Text position;
	public Text distance;
	public Text PathPointName;
	public GameObject Inputer;
	public int activePoint=0;
	private Vector3 ArrowDirection;
	private Vector3 MousePosition;
	public RaycastHit2D hit;

	void Awake()
	{
		signedPositions.Add (new PathPoint("CentrePoint",new Vector3 (0, 0, 0),false,null));
	}

	void Start () {
		
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.W) || Input.GetMouseButtonDown (2)) {
			MousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3 (0, 0, 100);
			hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero); 
			if (hit.collider == null) {
				Inputer.SetActive (true);
			}
			else
				AddPoint ();
		}
		if (signedPositions.Count!=0&&activePoint <= signedPositions.Count-1) {
			ArrowDirection = signedPositions [activePoint].position - ship.transform.position;
		}
		if(ArrowDirection.x>0)
			PathArrow.transform.rotation=Quaternion.Euler (0,0,-Vector2.Angle (new Vector2(0,1),ArrowDirection));
		if(ArrowDirection.x<=0)
			PathArrow.transform.rotation=Quaternion.Euler (0,0,Vector2.Angle (new Vector2(0,1),ArrowDirection));
		if (signedPositions.Count != 0) {
			position.text = signedPositions [activePoint].position.x.ToString ("F1") + "\n" + signedPositions [activePoint].position.y.ToString ("F1") + "\n" + signedPositions [activePoint].position.x.ToString ("F1") + "\n";
			distance.text = signedPositions [activePoint].name + ":\n" + ArrowDirection.magnitude.ToString ("F1");
		} else {
			position.text="No\nTarget";
			distance.text = "No Target";
		}
		if (Input.GetButtonDown ("Switch")) {
			activePoint++;
			if (activePoint > signedPositions.Count-1)
				activePoint = 0;
		}
		foreach (PathPoint pp in signedPositions) {
			if (pp.follow == true)
				pp.position = pp.fcelestialBody.transform.position;
		}
		if (Input.GetButtonDown ("Delete")) {
			Debug.Log (activePoint);
			if (signedPositions.Count - 1 > 0)
				signedPositions.Remove (signedPositions [activePoint]);
			else
				signedPositions.Clear ();
			if (activePoint > signedPositions.Count-1)
				activePoint --;
		}
		if (activePoint <= 0)
			activePoint = 0;
	}

	public void AddPoint()
	{
		if (hit.collider == null) {

			signedPositions.Add (new PathPoint (PathPointName.text, MousePosition, false, null));
		}
		else {
			foreach (PathPoint pp in signedPositions) {
				if (pp.fcelestialBody == hit.collider.gameObject)
					return;
			}
			signedPositions.Add (new PathPoint (hit.collider.gameObject.name, MousePosition, true, hit.collider.gameObject));
		}
		}

	public void BaseAdd(string myname,Vector3 myPosition,bool myfollow,GameObject myGameobject)
	{
		signedPositions.Add (new PathPoint (myname, myPosition, true, myGameobject));
	}
}
