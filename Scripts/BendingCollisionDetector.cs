using UnityEngine;
using System.Collections;

public class BendingCollisionDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//Destroy (gameObject,8f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collisionInfo){
		if(collisionInfo.collider.gameObject.CompareTag("EnemyLOW") == true){
			Debug.Log ("collision between projectile and enemy");
			//if(EnemySpawnSystem.index > 2){
			//	EnemySpawnSystem.index = 0;
			//}
//			EnemySpawnSystem.enemies[collisionInfo.collider.gameObject.GetComponent<EnemyClasses.Enemy>().indexPos].takeDamage(10);
			Destroy(gameObject);
			//Destroy (collisionInfo.collider.gameObject);
			return;

		}
		if(collisionInfo.collider.gameObject.CompareTag("Player") == true){
			Debug.Log ("collision between projectile and player");
			Player.takeDamage(10);
			Destroy (gameObject);
			return;
		}
		if(collisionInfo.collider.gameObject.CompareTag(gameObject.tag)){
			Destroy (collisionInfo.collider.gameObject);
			Destroy(gameObject);

		}

		if(collisionInfo.collider.gameObject.CompareTag("Air") == true){
			if(gameObject.CompareTag("Earth")){
				//player or enemy damage
				if(gameObject.transform.FindChild("source").CompareTag("Enemy1Attack") == true){
					Player.addPoints(10);
				}

				if(gameObject.transform.FindChild("source").CompareTag("Enemy2Attack") == true){
					Player.addPoints(10);
				}
				if(gameObject.transform.FindChild("source").CompareTag("Enemy3Attack") == true){
					Player.addPoints(10);
				}

				if(gameObject.transform.FindChild("source").CompareTag("PlayerAttack") == true){
					Player.takeDamage(10);
				}
				Destroy(collisionInfo.collider.gameObject);
				Destroy(gameObject);
			}

			if(gameObject.CompareTag("Water")){
				Destroy(collisionInfo.collider.gameObject);
				Destroy (gameObject);
			}
			
		}
		if(collisionInfo.collider.gameObject.CompareTag("Earth") == true){
			if(gameObject.CompareTag("Water")){
				//player or enemy damage
				if(gameObject.transform.FindChild("source").CompareTag("Enemy1Attack") == true){
					Player.addPoints(10);
				}
				
				if(gameObject.transform.FindChild("source").CompareTag("Enemy2Attack") == true){
					Player.addPoints(10);
				}
				if(gameObject.transform.FindChild("source").CompareTag("Enemy3Attack") == true){
					Player.addPoints(10);
				}
				
				if(gameObject.transform.FindChild("source").CompareTag("PlayerAttack") == true){
					Player.takeDamage(10);
				}
				Destroy(collisionInfo.collider.gameObject);
				Destroy(gameObject);
			}
			
			if(gameObject.CompareTag("Fire")){
				Destroy(collisionInfo.collider.gameObject);
				Destroy (gameObject);
			}
			
		}
		if(collisionInfo.collider.gameObject.CompareTag("Water") == true){
			if(gameObject.CompareTag("Fire")){
				//player or enemy damage
				if(gameObject.transform.FindChild("source").CompareTag("Enemy1Attack") == true){
					Player.addPoints(10);
				}
				
				if(gameObject.transform.FindChild("source").CompareTag("Enemy2Attack") == true){
					Player.addPoints(10);
				}
				if(gameObject.transform.FindChild("source").CompareTag("Enemy3Attack") == true){
					Player.addPoints(10);
				}
				
				if(gameObject.transform.FindChild("source").CompareTag("PlayerAttack") == true){
					Player.takeDamage(10);
				}
				Destroy(collisionInfo.collider.gameObject);
				Destroy(gameObject);
			}
			
		}
		if(collisionInfo.collider.gameObject.CompareTag("Fire") == true){
			if(gameObject.CompareTag("Air")){
				//player or enemy damage
				if(gameObject.transform.FindChild("source").CompareTag("Enemy1Attack") == true){
					Player.addPoints(10);
				}
				
				if(gameObject.transform.FindChild("source").CompareTag("Enemy2Attack") == true){
					Player.addPoints(10);
				}
				if(gameObject.transform.FindChild("source").CompareTag("Enemy3Attack") == true){
					Player.addPoints(10);
				}
				
				if(gameObject.transform.FindChild("source").CompareTag("PlayerAttack") == true){
					Player.takeDamage(10);
				}
				Destroy(collisionInfo.collider.gameObject);
				Destroy(gameObject);
			}
			
		}
		else{
			Destroy (gameObject,7f);
		}


	}
}
