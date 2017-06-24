using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	// Use this for initialization
	private float active_player_health = 100.0f;
	private PlayerProperties player_stats;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		Debug.Log (target);
		if (target.transform.tag == "Player") {
			Debug.Log ("spikez");
			player_stats = target.GetComponent<PlayerProperties> ();
			player_stats.health = 0.0f;
		}
	}
}
