using UnityEngine;
using System.Collections;

public class attackSymbol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(toggleIcon());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator toggleIcon(){
		while(true){
			if(EnemySpawnSystem.enemies[0].is_attacking){ //flash left button
				bool oddeven = Mathf.FloorToInt(Time.time)%2 == 0;
				gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
			}else if(EnemySpawnSystem.enemies[1].is_attacking){ //flash right button
				bool oddeven = Mathf.FloorToInt(Time.time)%2 == 0;
				gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
			}else if (EnemySpawnSystem.enemies[2].is_attacking){ //flash righ button
				bool oddeven = Mathf.FloorToInt(Time.time)%2 == 0;
				gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
			}

			yield return new WaitForSeconds(0.5f);
		}
	}
}
