using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour {

	public float maxHealth = 100.0f;
	public float health = 100.0f; // current health
	public float healthLossRate = 1.0f; // loss of health per second

	private float nextUpdateTime = 0.0f;
	private float updatePeriod = 0.1f;
	public bool loosing_life = true;
	// Use this for initialization
	void Start () {
		nextUpdateTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if ((Time.time > nextUpdateTime) && (loosing_life == true)) {
			nextUpdateTime += updatePeriod;
		//	health = health - (updatePeriod * healthLossRate);
			health = health - healthLossRate;
		}
	}
		
}