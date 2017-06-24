using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour {

	public float spawn_x = 0.0f;
	public float spawn_y = 0.0f;
	public float lives = 10.0f;

	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {

		// kill a player instantly with a kill button (testing only maybe)
		if (Input.GetKeyDown ("k")) {
				// get player location.. kill it, place a dead player in its place
				
			}
	}
}
