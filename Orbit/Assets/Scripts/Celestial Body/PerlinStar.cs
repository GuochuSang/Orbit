using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))] 
public class PerlinStar:CelestialBody {
		public int numberOfPoints = 10; 
		private float[] delta;
		public float xSeed, ySeed;
		public float perlinScale,perlinRange;
		private Mesh mesh; 
		private Vector3[] vertices;
		private Vector2[] points;
		private Vector2[] uv;
		private int[] triangles; 
		public float radius=1f;
		public PolygonCollider2D p2d;
	public override void Start () { 
		base.Start ();
			GetComponent<MeshFilter>().mesh = mesh = new Mesh(); 
			mesh.name = "Star Mesh"; 
			uv = new Vector2[numberOfPoints + 1];
			vertices = new Vector3[numberOfPoints + 1];
			delta = new float[numberOfPoints + 1];
			points = new Vector2[numberOfPoints];
			triangles = new int[numberOfPoints * 3];
		} 
	public override void Update()
		{
		base.Update ();
			float angle = -2*Mathf.PI / numberOfPoints; 
			for(int v = 1, t = 1; v < vertices.Length; v++, t += 3){ 
				float vAngle = angle * (v - 1);
				float vx = Mathf.Cos (vAngle) * radius;
				float vy = Mathf.Sin (vAngle) * radius;
				delta[v] = Mathf.PerlinNoise ((vx+xSeed)*perlinScale,(vy+ySeed)*perlinScale)*perlinRange;
				vertices [v] = new Vector3 (vx, vy, 0f).normalized*(radius+delta[v]);
				points [v-1] = new Vector2 (vertices[v].x,vertices[v].y);
				triangles[t] = v;
				triangles[t + 1] = v + 1;
			} 
			for (int i = 0; i < vertices.Length; i++) {
				uv [i] = new Vector2 ((vertices [i].normalized.x/2)*(delta[i]+radius)/radius+0.5f, (vertices [i].normalized.y/2)*(delta[i]+radius)/radius+0.5f);
			}
			triangles[triangles.Length - 1] = 1;
			mesh.vertices = vertices; 
			mesh.triangles = triangles; 
			mesh.uv=uv;
			xSeed += 0.01f;
			ySeed += 0.01f;
			p2d.SetPath (0,points);
		}
}
