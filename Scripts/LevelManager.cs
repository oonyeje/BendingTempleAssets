using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance;
	public static float currTime = 0;
	public float limit = 50;
	public int level = 1;
	public int numEnemies = 0;
	public static int totalPoints = 0;
	public int beatenEnemies = 0;
	public bool levelTransition = false;
	public bool game_over = false;
	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
		}else{
			Object.Destroy(this.gameObject);
		}
		DontDestroyOnLoad(transform.gameObject);


	}
	//void Awake() {

	//}
	// Update is called once per frame
	void Update () {
		if(levelTransition == true){
			level = level + 1;
			limit = limit + 25;
			currTime = 0;
			levelTransition = false;
		}
		currTime += Time.deltaTime;
		if(game_over == true){
			limit = 50;
			level = 1;
			Application.LoadLevel("game over scene");
			game_over = false;
		}
		checkPlayer();
		checkTime ();
	}

	public void checkPlayer(){
		if(Player.health == 0){
			for(int i = 0; i < 3; i++){
				if(EnemySpawnSystem.filled[i] == true){
					Destroy(EnemySpawnSystem.enemyModels[i]);
					Destroy (EnemySpawnSystem.enemies[i]);
					EnemySpawnSystem.filled[i] = false;
				}
			}
			totalPoints = totalPoints + Player.accumPoints;
			currTime = 0;
			LoadingManager.add_to_order("combat scene");
			game_over = true;
			Player.health = 30;
		}

	}

	public void checkTime(){
		if(currTime >= limit){
			for(int i = 0; i < 3; i++){
				if(EnemySpawnSystem.filled[i] == true){
					Destroy(EnemySpawnSystem.enemyModels[i]);
					Destroy (EnemySpawnSystem.enemies[i]);
					EnemySpawnSystem.filled[i] = false;
				}
			}
			totalPoints = totalPoints + Player.accumPoints;
			levelTransition = true;
			LoadingManager.add_to_order("combat scene");
			Application.LoadLevel("loading scene");
		}

	}
}
