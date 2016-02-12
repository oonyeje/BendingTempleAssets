using UnityEngine;
using System.Collections;

public class skillTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.LookAt(Camera.main.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
