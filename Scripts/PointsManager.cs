using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<GUIText>().text = Mathf.CeilToInt(LevelManager.totalPoints + Player.accumPoints).ToString("F0");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<GUIText>().text = Mathf.CeilToInt(LevelManager.totalPoints + Player.accumPoints).ToString("F0");
	}
}
