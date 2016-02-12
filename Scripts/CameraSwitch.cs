using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PlayerStandin");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LookAtPlayer(){
		Camera.main.transform.LookAt (player.transform.position);
	}
}
