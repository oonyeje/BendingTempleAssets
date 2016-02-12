using UnityEngine;
using System.Collections;
using ElementProperties;

namespace EnemyClasses{

	public class Enemy : MonoBehaviour {
		public int health;
		public static int numOfEnemies = 0;
		public bool is_attacking = false;
		public static bool enemyAttack;
		public GameObject prefab;
		public int indexPos;
		// Use this for initialization

		void Awake(){
			numOfEnemies++;
		}
		public Enemy(){
			this.health = 100;

			this.prefab = (GameObject)Resources.Load("EnemyBender", typeof(GameObject) );
			this.indexPos = EnemySpawnSystem.index;
		}


		// Update is called once per frame
		void Update () {
			gameObject.transform.LookAt(Camera.main.transform.position);
		}

		public void toggle_attack(){
			if(enemyAttack == false){
				is_attacking = enemyAttack = true;

				gameObject.GetComponent<Animator>().SetInteger("canAttack", 1);
			}else
				is_attacking = enemyAttack = false;
		}

	}
}