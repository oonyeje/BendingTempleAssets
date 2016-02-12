using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EnemyClasses;

public class EnemySpawnSystem : MonoBehaviour {
	public static Transform[] spawnPositions = new Transform[3]; //stores spawnpoints for each enemy
	public static Enemy[] enemies = new Enemy[3]; //stores Enemy info for each enemy
	public static GameObject[] enemyModels = new GameObject[3]; //stores actual game object for each enemy
	public static bool[] filled = new bool[3]; // associative array to store whether enemy exists at spawnpoint
	protected bool max = false;
	public static int index= 0;               //current working index of SpawnSystem
	public static Queue<Enemy> waiting_to_attack = new Queue<Enemy>();  //Queue to log Enemies' order of attacks
	private bool firstAttack = true;
	private static int count = 0;
	public int last_picked = 3;
	public static EnemySpawnSystem instance; //for singleton class
	// Use this for initialization
	void Awake () {

		spawnPositions[0] = GameObject.Find("Spawnpoint(1)").transform;
		spawnPositions[1] = GameObject.Find("Spawnpoint(2)").transform;	
		spawnPositions[2] = GameObject.Find("Spawnpoint(3)").transform;

	}
	// Update is called once per frame
	void Update () {
		//this will handle enqueing and 
		int attacker = Random.Range (0,3); //chooses attacker
		if(attacker == last_picked){ //makes sure there is no immediate repeat attack from same enemy 
			if(attacker == 2){
				attacker = Random.Range (0,2);
			}else{
				attacker++;
			}
		}
		if(filled[attacker] == true){
			if(count < 3){
				waiting_to_attack.Enqueue(enemies[attacker]); // queues a new enemy attack
				count++;
				last_picked = attacker; //sets new last attacker
			}
			try_to_dequeue(); //checks to see if it is okay for an enemy to attack
		}







	}

	void Start() {

		if(instance == null){ //checks if singleton exist or not
			instance = this;
		}else{ //if exists
			waiting_to_attack.Clear(); //clear the list of enemy attacks
			waiting_to_attack.TrimExcess(); //trims queue to original capacity
			Enemy.enemyAttack = false; //resets enemy permission to attack
			count = 0;
			Object.Destroy(this.gameObject); // destroys potential new instance of SpawnSystem
			index = 0;
		}
		DontDestroyOnLoad(transform.gameObject);
		spawn();
	}


	public void spawn(){
		Invoke ("wait", 5f);
		for(int i = 0; i<3;i++){

			if(filled[i] == false){
				enemyModels[i] = ((GameObject)Instantiate(Resources.Load("EnemyBender", typeof(GameObject)), spawnPositions[i].position, spawnPositions[i].rotation));
				enemyModels[i].AddComponent<Enemy>();
				enemies[i] = enemyModels[i].GetComponent<Enemy>();
				enemyModels[i].transform.LookAt(Camera.main.transform.position);
				filled[i] = true;
				EnemySpawnSystem.index++;
			}
				

		}
	}

	public void try_to_dequeue(){
		if(Enemy.enemyAttack == false && count > 0){
			Enemy attackingEnemy = waiting_to_attack.Dequeue();
			attackingEnemy.toggle_attack();
			count--;
		}
	}

	private void wait(){

	}
}
