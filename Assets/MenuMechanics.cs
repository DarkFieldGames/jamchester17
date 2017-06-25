using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;

public class MenuMechanics : MonoBehaviour {

	public string next_level = "level1";

	public void NextLevel(){
		Debug.Log ("next level");
		SceneManager.LoadScene(next_level);	
	}

	public void ExitGame(){
		Application.Quit();
	}

}
