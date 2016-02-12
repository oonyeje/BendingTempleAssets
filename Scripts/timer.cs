using UnityEngine;
using System.Collections;
using System;

public class timer : MonoBehaviour {
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<GUIText>().text = Mathf.CeilToInt(LevelManager.currTime).ToString("F0");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<GUIText>().text = Mathf.CeilToInt(LevelManager.currTime).ToString("F0");
	}
}
