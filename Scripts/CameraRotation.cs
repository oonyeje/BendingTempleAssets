using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
	public float speedMod = 2.0f;
	public Vector3 point;

	// Use this for initialization
	void Start () {
		point = GameObject.Find ("CameraAxis").transform.position;
		transform.LookAt (point);
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (point, new Vector3 (0.0f, 1.0f, 0.0f), 
		                        20 * Time.deltaTime * speedMod);
	}
}
