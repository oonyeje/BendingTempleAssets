using UnityEngine;
using System.Collections;
using EnemyClasses;

public class AttackSystem : MonoBehaviour {
	public static Queue waiting_to_attack;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("EnemySpawnSystem").GetComponent<EnemySpawnSystem>()){

		}
	}
}
