using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarScript : MonoBehaviour {

	private Text lives_counter;
	private GameObject gamelogic;
	private GameMechanics gamemech;
	// Use this for initialization
	void Start () {
		gamelogic = GameObject.FindGameObjectWithTag ("GameLogic");
		lives_counter = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		gamelogic = GameObject.FindGameObjectWithTag ("GameLogic");
		gamemech = gamelogic.GetComponent<GameMechanics> ();
		lives_counter = gameObject.GetComponent<Text> ();
		lives_counter.text = (gamemech.lives).ToString ();
	}
}
