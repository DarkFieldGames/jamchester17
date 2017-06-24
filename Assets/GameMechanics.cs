using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;

public class GameMechanics : MonoBehaviour {

	public float spawn_x = 0.0f;
	public float spawn_y = 0.0f;
	public int lives = 10;
	public float player_x = 0.0f;
	public float player_y = 0.0f;
	public string next_level = "level2";
	public bool level_won = false;


	private float active_player_health = 100.0f;

	private GameObject ActivePlayer;
	public GameObject NewPlayer;
	public GameObject DeadPlayer;
	public GameObject ExitDoor;

	private GameObject Camera;
	private Camera2DFollow camera_logic;

	// Use this for initialization
	void Awake () {
		ActivePlayer = GameObject.FindGameObjectWithTag("Player");
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		ExitDoor = GameObject.FindGameObjectWithTag ("ExitDoor");
		level_won = false;
//		NewPlayer = Resources.Load ("Player") as GameObject;
//		DeadPlayer = Resources.Load("DeadPlayer") as GameObject;
	}

	void KillPlayer() {
		if (lives == 0) {
			// TODO GameOVer logic
			Destroy (ActivePlayer);
			Debug.Log ("Game Over");
			Debug.Log (lives);
		} else {
			player_x = ActivePlayer.transform.position.x;
			player_y = ActivePlayer.transform.position.y;
			Vector2 dead_pos = new Vector2 (player_x, player_y);
			Vector2 spawn_pos = new Vector2 (spawn_x, spawn_y);
			Instantiate (NewPlayer, spawn_pos, Quaternion.identity);
			Destroy (ActivePlayer);
			Instantiate (DeadPlayer, dead_pos, Quaternion.identity);
			ActivePlayer = GameObject.FindGameObjectWithTag("Player"); // update active player
			ActivePlayer.GetComponent<PlayerProperties>().health = 100.0f;
			camera_logic = Camera.GetComponent<Camera2DFollow>();
			camera_logic.target = ActivePlayer.transform;
			lives = lives - 1;
		}
		Debug.Log (lives);
		//GameObject.FindGameObjectWithTag("Player"); // always refresh who the player is incase it dies
	}

	void NextLevel(){
		Debug.Log ("next level");
		SceneManager.LoadScene(next_level);
		level_won = false;		
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("OnTriggerEnter");
		Debug.Log(other.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		ActivePlayer = GameObject.FindGameObjectWithTag("Player");
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		active_player_health = ActivePlayer.GetComponent<PlayerProperties> ().health;
		// kill a player instantly with a kill button (testing only maybe)
		if (ActivePlayer != null) {
			if (Input.GetKeyDown ("k") || active_player_health <= 0.0f) {
				// get player location.. kill it, place a dead player in its place
				KillPlayer ();
			}

		Debug.Log (level_won);
		if (level_won == true) {
			NextLevel ();
		}

		}
	}
}
