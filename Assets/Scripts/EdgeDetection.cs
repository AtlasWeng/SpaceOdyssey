using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetection : MonoBehaviour {
	private LevelManager levelManager;

	// Use this for initialization
	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.CompareTag ("Player")) {
			Debug.Log ("Player Crash Edge");
			levelManager.LoadLevel ("GameOverScene");
		} else if (collider.CompareTag ("Target")) {
			Debug.Log ("Poole fly away");
			levelManager.LoadLevel("GameOverScene");
		}
	}
}
