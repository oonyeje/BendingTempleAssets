using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadingManager : MonoBehaviour
{
	private bool loading;
	private static LoadingManager instance;
	public GUIText texture;
	public static LinkedList<string> scene_order = new LinkedList<string>();
	public static bool coroutine_begin = false;


	void Start(){
		if(instance == null){
			instance = this;

		}else{
			Object.Destroy(this.gameObject);
		}
		DontDestroyOnLoad(transform.gameObject);

	}

	void Update () {
		if(Application.loadedLevelName == "loading scene" && LoadingManager.coroutine_begin == false){
			texture = GameObject.Find("loading_name").GetComponent<GUIText>();
			StartCoroutine(load_lev(1, false));
			LoadingManager.coroutine_begin = true;
		}
		if(Application.loadedLevelName == "game over scene" && LoadingManager.coroutine_begin == false && LoadingManager.scene_order.First.Value != "game over scene"){
			LoadingManager.add_to_order(Application.loadedLevelName);
			texture = GameObject.Find("gameover_text").GetComponent<GUIText>();
			StartCoroutine(load_lev(2, true));
			LoadingManager.coroutine_begin = true;
		}


	}
	


	IEnumerator load_lev(int option, bool gameOV){
		if(option == 1){
			for(int i = 0; i < 12; i++){
				if(i == 11){
					texture.text = "Loading";
					LoadingManager.coroutine_begin = false;
					LevelManager.currTime = 0;
					if(LoadingManager.scene_order.First.Value == "Start Screen"){
						Application.LoadLevel("combat scene");
					}else if(LoadingManager.scene_order.First.Value == "combat scene"){
						Application.LoadLevel("combat scene");
					}else if(LoadingManager.scene_order.First.Value == "game over scene"){
						Application.LoadLevel("combat scene");
					}
				}else{
					if(i == 6){
						texture.text = "Loading";
					}
					
					texture.text = texture.text + ".";
				}
				yield return new WaitForSeconds(1f);
			}
		}else{
			if(gameOV == true){
				for(int i = 0; i < 10; i++){
					switch(i){
					case 0:
						texture.text = texture.text + "G";
						break;
					case 1:
						texture.text = texture.text + "A";
						break;
					case 2:
						texture.text = texture.text + "M";
						break;
					case 3:
						texture.text = texture.text + "E";
						break;
					case 4:
						texture.text = texture.text + " O";
						break;
					case 5:
						texture.text = texture.text + "V";
						break;
					case 6:
						texture.text = texture.text + "E";
						break;
					case 7:
						texture.text = texture.text + "R";
						break;
					case 8:
						texture.text = texture.text + "!";
						break;
					default:
						GameOverGui.gui_toggle = true;
						gameOV = false;
						break;
					}
					yield return new WaitForSeconds(0.75f);
				}
			}

		}

	}

	public static void add_to_order(string str){
		LoadingManager.scene_order.AddFirst(str);
	}
}
	
