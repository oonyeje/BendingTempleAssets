using UnityEngine;
using System.Collections;

public class PlayerPanning : MonoBehaviour {
	public Transform mainCamera;
	public Transform cameraTRS;
	//public Transform cameraTrs;
	public int rotationSpeed = 10;
	//private GameObject target;
	private int num = 0;
	private int numBck = 0;
	private Vector3 initPos;
	private int cameraRotCon = 1;


	// Use this for initialization
	void Start () {
		mainCamera = gameObject.transform;
		cameraTRS = gameObject.gameObject.transform;
		//target = GameObject.Find ("Podium3");
		initPos = mainCamera.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt (target.transform);
		if (cameraRotCon == 1) {
			cameraTRS.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		}

		float x = mainCamera.localPosition.x;
		float y = mainCamera.localPosition.y;
		float z = mainCamera.localPosition.z;

		if(num > numBck){
			y += 0.05f;
			z -=0.3f;
			num = numBck;
			mainCamera.localPosition.Set(x, y, z);

		}else if(num > numBck){
			y += 0.05f;
			z -=0.3f;
			num = numBck;
			mainCamera.localPosition.Set(x, y, z);

		}else if(num == 0){
			mainCamera.localPosition.Set(x, initPos.y, initPos.z);
		}

		if (mainCamera.localPosition.y < initPos.y) {
			mainCamera.localPosition.Set (x, initPos.y, z);
		}
		if (mainCamera.localPosition.z > initPos.z) {
			mainCamera.localPosition.Set ( x ,y , initPos.z);
		}
	}
}
