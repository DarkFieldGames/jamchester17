using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

	// Use this for initialization
	public GameObject gamemechanics; 
	void Start () {
		gamemechanics = GameObject.FindGameObjectWithTag ("GameLogic");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.transform.parent.tag == "Player") {
			Debug.Log ("winner");
			GameMechanics gamemech = gamemechanics.GetComponent<GameMechanics> ();
			gamemech.level_won = true;
			Debug.Log (gamemech.level_won);
		}
	}
}
