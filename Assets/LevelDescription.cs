using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDescription : MonoBehaviour {

	private Text level_description;
	private GameObject gamelogic;
	private GameMechanics gamemech;
	// Use this for initialization
	void Start () {
		gamelogic = GameObject.FindGameObjectWithTag ("GameLogic");
		level_description = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		gamelogic = GameObject.FindGameObjectWithTag ("GameLogic");
		gamemech = gamelogic.GetComponent<GameMechanics> ();
		level_description = gameObject.GetComponent<Text> ();
		level_description.text = (gamemech.level_description).ToString ();
		Debug.Log (level_description.text);
	}
}
