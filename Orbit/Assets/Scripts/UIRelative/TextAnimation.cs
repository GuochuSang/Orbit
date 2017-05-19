using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using UnityEditor;

public class TextAnimation : MonoBehaviour {
	private string text;
	public float playC;
	private Text UItext;
	// Use this for initialization
	void Start () {
		UItext = GetComponent <Text> ();
		text = UItext.text;
	}
	
	// Update is called once per frame
	void Update () {
		string textt="";
		for (int i = 0; i < playC && i < text.Length; i++)
			textt += text [i].ToString ();
		UItext.text = textt;
	}

	}
