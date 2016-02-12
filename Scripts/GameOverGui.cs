using UnityEngine;
using System.Collections;

public class GameOverGui : MonoBehaviour {
	public static bool gui_toggle = false;
	public GUIStyle myStyle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(gui_toggle == true){
//			GUI.Box (new Rect (55+50,80+80,Screen.width-200,Screen.height - 500), "Menu");
		if(GUI.Button(new Rect((Screen.width - 380)/2, (Screen.height - 480)/5 +120, 380, 120), "Play Again?", myStyle)){
				LevelManager.currTime = 0;
				LevelManager.totalPoints =0;
				Application.LoadLevel("loading scene");
				LoadingManager.coroutine_begin = false;
				gui_toggle = false;
			}
			
		if (GUI.Button (new Rect((Screen.width - 380)/2, (Screen.height - 480)/5 +240, 380, 120), "Log Scores", myStyle)) {
				//create a scroll box
			}
			
		if(GUI.Button (new Rect((Screen.width - 380)/2, (Screen.height - 480)/5 +360, 380, 120), "Quit Game", myStyle)){
				LoadingManager.coroutine_begin = true;
				Application.Quit();
			}
		}
	}
}
