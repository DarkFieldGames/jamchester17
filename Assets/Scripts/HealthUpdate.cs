using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour {

	private float nextUpdateTime = 0.0f;
	private float updatePeriod = 0.02f;
	private GameObject player;
	private Image playerhealthbar;
	private float playerhealth = 0.0f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerhealthbar = GameObject.Find("LifeBarFull").GetComponent<Image>();
		nextUpdateTime = 0.0f;
		playerhealth = player.GetComponent<PlayerProperties> ().health;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time > nextUpdateTime)) {
			nextUpdateTime += updatePeriod;
			if (player != null) {
				playerhealth = player.GetComponent<PlayerProperties> ().health;
				playerhealthbar.fillAmount = playerhealth / 100.0f;
			}
		}
	}

	private void LateUpdate(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}
}
