using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {
	public GUIStyle myStyle;
	private Vector2 scrollPosition;
	// Use this for initialization
	void Start () {

		scrollPosition = new Vector2(scrollPosition.x, Mathf.Infinity);

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI () {



		//GUI.Box (new Rect (0,0,Screen.width,Screen.height), "Main Menu");

		if(GUI.Button(new Rect((Screen.width - 380)/2, (Screen.height - 510)/4, 380, 170), "Start Game", myStyle)){
			LoadingManager.add_to_order(Application.loadedLevelName);
			Application.LoadLevel("loading scene");
		}

		if (GUI.Button (new Rect((Screen.width - 380)/2, ((Screen.height - 510)/4)*2 + 170 , 380, 170), "How to Play", myStyle)) {
			//create a scroll box
		}

		if(GUI.Button (new Rect((Screen.width - 380)/2, ((Screen.height - 510)/4)*3 + 340, 380, 170), "High Scores", myStyle)){
			//show a scroll box with high scores
		}
	}
	
}
