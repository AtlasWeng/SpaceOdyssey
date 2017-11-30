using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	public LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.CompareTag ("Target")) {
			levelManager.LoadLevel("WinScene");
		}

	}
}
