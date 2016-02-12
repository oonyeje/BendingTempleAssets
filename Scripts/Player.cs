using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static int health; // use this to also determine when level ends
	public static int accumPoints; //this will be added to the total points which will be handled by the level manager
	public int powerlevel = 10;
	public static Player instance;
	public GameObject prefab;
	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
			health = 30;
			accumPoints = 0;
			prefab = (GameObject)Resources.Load("Player", typeof(GameObject) );
		}else{
			Object.Destroy(this.gameObject);
		}
		DontDestroyOnLoad(transform.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void takeDamage(int damage){
		if((health = health - damage) <= 0){
			//send the accumulated points to level manager and end game
			Destroy(GameObject.FindGameObjectWithTag("Player"));
			LevelManager levelMan = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
			levelMan.checkPlayer();
		}
	}

	public static void addPoints(int points){
		accumPoints += points;
	}
}
