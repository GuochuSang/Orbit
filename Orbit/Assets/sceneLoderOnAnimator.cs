using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoderOnAnimator : MonoBehaviour {
	public float LoderThreshold;
	public bool SceneLoderFuction;
	public string sceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneLoderFuction && LoderThreshold >= 1f)
			SceneManager.LoadScene (sceneName);
		else if(!SceneLoderFuction && LoderThreshold >= 1)	
		{
			DoFuction();
		}
	}
	public void DoFuction()
	{
		
	}
}
