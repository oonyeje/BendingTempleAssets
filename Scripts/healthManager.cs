using UnityEngine;
using System.Collections;

public class healthManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<GUITexture>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		checkVisibility();
	}

	static void checkVisibility(){
		if(Player.health == 30){
			GameObject.FindGameObjectWithTag("Health_3").GetComponent<GUITexture>().enabled = true;
			GameObject.FindGameObjectWithTag("Health_2").GetComponent<GUITexture>().enabled = true;
			GameObject.FindGameObjectWithTag("Health_1").GetComponent<GUITexture>().enabled = true;
		}else if(Player.health == 20){
			GameObject.FindGameObjectWithTag("Health_3").GetComponent<GUITexture>().enabled = false;
			GameObject.FindGameObjectWithTag("Health_2").GetComponent<GUITexture>().enabled = true;
			GameObject.FindGameObjectWithTag("Health_1").GetComponent<GUITexture>().enabled = true;
		}else if(Player.health == 10){
			GameObject.FindGameObjectWithTag("Health_3").GetComponent<GUITexture>().enabled = false;
			GameObject.FindGameObjectWithTag("Health_2").GetComponent<GUITexture>().enabled = false;
			GameObject.FindGameObjectWithTag("Health_1").GetComponent<GUITexture>().enabled = true;
		}else{
			GameObject.FindGameObjectWithTag("Health_3").GetComponent<GUITexture>().enabled = false;
			GameObject.FindGameObjectWithTag("Health_2").GetComponent<GUITexture>().enabled = false;
			GameObject.FindGameObjectWithTag("Health_1").GetComponent<GUITexture>().enabled = false;
		}
	}
}
