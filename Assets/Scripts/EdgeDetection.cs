using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetection : MonoBehaviour {

	// Use this for initialization
	void Start(){
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		Vector2 tweak = new Vector2 (Random.Range (.1f, .5f), Random.Range (.1f, .5f));
		if (GameManager.gm.gameStart) {
			collision.gameObject.GetComponent<Rigidbody2D> ().velocity += tweak;
		}

		if (collision.gameObject.tag == "Player") {
			GameManager.gm.gameTime -= 5;
		}

	} 
}
