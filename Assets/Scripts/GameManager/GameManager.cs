using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;

public class GameManager : MonoBehaviour {
    public static GameManager Instance {
		get {
			return instance;
		}

	}
	private static GameManager instance;

	public float gravitionalConstant = 6;
	public bool isPaused = false;
	public bool inputAllowed = true;
    void Awake(){
		if (instance) {
			DestroyImmediate (gameObject);
			return;
		}
		instance = this;
		//DontDestroyOnLoad (gameObject);
    }
	void Update()
	{
		if (isPaused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}
