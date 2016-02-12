using UnityEngine;
using System.Collections;

public class UIControls : MonoBehaviour {
	public float speed = 0.5f;
	private int right = 1; // used to reference player orientation with respect to number of right turns available
	private int left = 1; // used to reference player orientation with respect to number of left turns available
	private GUITexture leftArrow; //for left pan button
	private GUITexture rightArrow; //for right pan button
	private SpriteRenderer leftArrowFlash; //game object used for left turn indicator
	private SpriteRenderer rightArrowFlash; //game object used for right turn indicator
	private GUITexture fire; //for fire bending skill select
	private GUITexture water; //for water bending skill select
	private GUITexture earth; // for earth bending skill select
	private GUITexture air;  // for air bending skill select
	public GUIStyle myStyle;

	private bool leftBool, rightBool = false;
	private float t;

	void Start () {
		//assigns ui game objects
		leftArrow = GameObject.Find("LeftArrow").GetComponent<GUITexture>(); 
		rightArrow = GameObject.Find("RightArrow").GetComponent<GUITexture>();
		fire = GameObject.Find("FireBend").GetComponent<GUITexture>();
		water = GameObject.Find ("WaterBend").GetComponent<GUITexture>();
		earth = GameObject.Find ("EarthBend").GetComponent<GUITexture>();
		air = GameObject.Find ("AirBend").GetComponent<GUITexture>();
		leftArrowFlash  = GameObject.Find("LeftFlash").GetComponent<SpriteRenderer>(); 
		rightArrowFlash  = GameObject.Find("RightFlash").GetComponent<SpriteRenderer>();
		leftArrowFlash.enabled = false; //disables left sprite renderer to show "no turn"
		rightArrowFlash.enabled = false; //disables right sprite renderer to show "no turn"

		GameObject Player = (GameObject)Instantiate(Resources.Load("Player", typeof(GameObject)), Camera.main.transform.position, Camera.main.transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		if(leftBool == true){
//			t = Mathf.Min(t+speed*Time.deltaTime, 1); 
//			Vector3 camDes = new Vector3(0f,-90f,0f);
//			Vector3 playDes = new Vector3(0f,-90f,0f);
//			Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.rotation.eulerAngles, camDes, t);
//			GameObject.FindGameObjectWithTag("Player").transform.eulerAngles = Vector3.Lerp (GameObject.FindGameObjectWithTag("Player").transform.rotation.eulerAngles, playDes, t);
			leftBool = false;
		}

		if(rightBool == true){
//			t = Mathf.Min(t+speed*Time.deltaTime, 1);
//			Quaternion camDes = Quaternion.Euler(0f,90f,0f);
//			Quaternion playDes = Quaternion.Euler(0f,90f,0f);
//			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, camDes, t);
//			GameObject.FindGameObjectWithTag("Player").transform.rotation = Quaternion.Lerp(GameObject.FindGameObjectWithTag("Player").transform.rotation, playDes, t);
			rightBool = false;
		}


		if(left == 1 && right == 1&& EnemySpawnSystem.enemies[0].is_attacking){ //flash left indicator if enemy on left is attacking
			bool oddeven = Mathf.FloorToInt(Time.time)%2 == 0;
			leftArrowFlash.enabled = oddeven;
			Debug.Log("left[absolute left attacking]");
		}else if(right == 1 && left == 1 && EnemySpawnSystem.enemies[2].is_attacking){ //flash right indicator if enemy on right is attacking
			bool oddeven = Mathf.FloorToInt(Time.time)%2 == 0;
			rightArrowFlash.enabled = oddeven;
			Debug.Log("right[absolute right attacking]");
		}else if(left == 0 && (EnemySpawnSystem.enemies[1].is_attacking)){ //flash right indicator if player is facing absolut left and center enemy to player's right is attacking
			bool oddeven = Mathf.FloorToInt(Time.time)%2 == 0;
			rightArrowFlash.enabled = oddeven;
			Debug.Log("right[center attacking]");
		}else if(left == 0 && (EnemySpawnSystem.enemies[2].is_attacking)){ //flash right indicator if player is facing absolut left and the absolute right enemy to player's right is attacking
			bool oddeven = Mathf.FloorToInt(Time.time)%2 == 0;
			rightArrowFlash.enabled = oddeven;
			Debug.Log("right[absolute right attacking]");
		}else if(right == 0 && ((EnemySpawnSystem.enemies[1].is_attacking))){ //flash left indicator if player is facing absolut right and center enemy to player's left is attacking
			bool oddeven = Mathf.FloorToInt(Time.time)%2 == 0;
			leftArrowFlash.enabled = oddeven;
			Debug.Log("left[center attacking]");
		}else if(right == 0 && ((EnemySpawnSystem.enemies[0].is_attacking))){ //flash left indicator if player is facing absolut right and the absolute left enemy to player's left is attacking
			bool oddeven = Mathf.FloorToInt(Time.time)%2 == 0;
			leftArrowFlash.enabled = oddeven;
			Debug.Log("left[absolute left attacking]");
		}else{
			leftArrowFlash.enabled = false;
			rightArrowFlash.enabled = false;
			Debug.Log ("none[facing attacker]");
		}

	}


	void OnGUI(){
		if (left > 0 && GUI.Button (new Rect (60, Screen.height/2 -30, 50, 100), leftArrow.texture)) { 
			Camera.main.transform.Rotate (new Vector3 (0, -90, 0));
			GameObject.FindGameObjectWithTag("Player").transform.Rotate(new Vector3(0, -90, 0));
			//GameObject.Find("Monk_hand_attack").transform.Rotate(new Vector3(0,-90,0));
			t = 0;
			leftBool = true;
			this.left--; 
			this.right++;
			StopAllCoroutines();
			//StartCoroutine(RotateObject(Camera.main.transform, 1));
		}

		if (right > 0 && GUI.Button (new Rect (375, Screen.height/2 - 30, 50, 100), rightArrow.texture)) {
			Camera.main.transform.Rotate (new Vector3 (0, 90, 0));
			GameObject.FindGameObjectWithTag("Player").transform.Rotate(new Vector3(0, 90, 0));
			//GameObject.Find("Monk_hand_attack").transform.Rotate(new Vector3(0,90,0));
			t = 0;
			rightBool = true;
			this.right--;
			this.left++;
			StopAllCoroutines();
			//StartCoroutine(RotateObject(Camera.main.transform, 0));
		}
		if(GUI.Button(new Rect(((Screen.width -320)/5), 650, 80, 80),  fire.texture)){
			Debug.Log("FireBend");
			GameObject.Find("Monk_hand_attack").GetComponent<Animator>().SetBool("playerAttack",true);
			Invoke("LaunchFire", 0.3f);

		}
		if(GUI.Button(new Rect(((Screen.width -320)/5)*2 + 80, 650, 80, 80),  water.texture)){
			//do something
			Debug.Log("WaterBend");
			GameObject.Find("Monk_hand_attack").GetComponent<Animator>().SetBool("playerAttack",true);
			Invoke("LaunchWater", 0.3f);
		}
		if(GUI.Button(new Rect(((Screen.width -320)/5)*3 + 160, 650, 80, 80),  earth.texture)){
			//do something
			Debug.Log("EarthBend");
			GameObject.Find("Monk_hand_attack").GetComponent<Animator>().SetBool("playerAttack",true);
			Invoke("LaunchEarth", 0.3f);
		}
		if(GUI.Button(new Rect(((Screen.width -320)/5)*4 + 240, 650, 80, 80),  air.texture)){
			//do something
			Debug.Log("AirBend");
			GameObject.Find("Monk_hand_attack").GetComponent<Animator>().SetBool("playerAttack",true);
			Invoke("LaunchAir", 0.3f);
		}


	}

	IEnumerator RotateObject(Transform thisTransform, int mode){
		for(int i = 1; i <= 45; i++) {
			if(mode == 0){
				thisTransform.rotation = Quaternion.AngleAxis((float)(2*i),Vector3.up);
			}
			else{
				thisTransform.rotation = Quaternion.AngleAxis((float)-(2*i),Vector3.up);
			}

			yield return new WaitForSeconds(0.000000000000000000000000000000000001f);
		}
		yield break;
	}

	void LaunchFire(){
		GameObject FireBend = (GameObject)Instantiate(Resources.Load("FireBend", typeof(GameObject)), Camera.main.transform.position, Camera.main.transform.rotation);
		FireBend.transform.FindChild("source").gameObject.tag = "PlayerAttack";
		Physics.IgnoreCollision(FireBend.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());
		FireBend.GetComponent<Rigidbody>().velocity = FireBend.transform.TransformDirection(Vector3.forward * 15);

	}

	void LaunchWater(){
		GameObject WaterBend = (GameObject)Instantiate(Resources.Load("WaterBend", typeof(GameObject)), Camera.main.transform.position, Camera.main.transform.rotation);
		WaterBend.transform.FindChild("source").gameObject.tag = "PlayerAttack";
		Physics.IgnoreCollision(WaterBend.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());
		WaterBend.GetComponent<Rigidbody>().velocity = WaterBend.transform.TransformDirection(Vector3.forward * 15);
	}

	void LaunchEarth(){
		GameObject EarthBend = (GameObject)Instantiate(Resources.Load("EarthBend", typeof(GameObject)), Camera.main.transform.position, Camera.main.transform.rotation);
		EarthBend.transform.FindChild("source").gameObject.tag = "PlayerAttack";
		Physics.IgnoreCollision(EarthBend.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());
		EarthBend.GetComponent<Rigidbody>().velocity = EarthBend.transform.TransformDirection(Vector3.forward * 15);
	}
	
	void LaunchAir(){
		GameObject AirBend = (GameObject)Instantiate(Resources.Load("AirBend", typeof(GameObject)), Camera.main.transform.position, Camera.main.transform.rotation);
		AirBend.transform.FindChild("source").gameObject.tag = "PlayerAttack";
		Physics.IgnoreCollision(AirBend.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());
		AirBend.GetComponent<Rigidbody>().velocity = AirBend.transform.TransformDirection(Vector3.forward * 15);
	}


}