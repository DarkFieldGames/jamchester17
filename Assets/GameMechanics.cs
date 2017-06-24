using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour {

	public float spawn_x = 0.0f;
	public float spawn_y = 0.0f;
	public int lives = 10;
	public GameObject ActivePlayer = GameObject.FindGameObjectWithTag("Player");
	public GameObject DeadPlayer = GameObject.FindGameObjectWithTag("DeadPlayer");
	public float player_x = 0.0f;
	public float player_y = 0.0f;

	// Use this for initialization
	void Start () {
		
	}

	void KillPlayer() {
		player_x = ActivePlayer.transform.position.x;
		player_y = ActivePlayer.transform.position.y;
		Vector2 dead_pos = new Vector2 (player_x, player_y);
		Destroy (ActivePlayer);
		Instantiate (DeadPlayer, dead_pos, Quaternion.identity);
		Vector2 spawn_pos = new Vector2 (spawn_x, spawn_y);
		Instantiate (ActivePlayer, spawn_pos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

		// kill a player instantly with a kill button (testing only maybe)
		if (Input.GetKeyDown ("k")) {
			// get player location.. kill it, place a dead player in its place
			KillPlayer();
		}
	}
}
