using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	private LevelManager levelManager;
	private Poole poole;

	// ani tracking

	// store reference to component on gameObject
	Animator _animator;

	void Awake(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		poole = GameObject.FindObjectOfType<Poole>();
		_animator = this.GetComponent<Animator>();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.CompareTag ("Target") && poole.collected) {
			levelManager.LoadLevel("WinScene");
		}
	}

	void Update(){
		DeathCounting();
	}

	void DeathCounting ()
	{
		if (GameManager.gm.gameTime <= 20 || poole.collected) {
			_animator.SetTrigger("DeathCounting");
		}
	}
}
