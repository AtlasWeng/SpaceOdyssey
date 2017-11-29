using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePod : MonoBehaviour {
	private Rigidbody2D rb;

	[Header("SpaceOdd")]
	[Range(0, 10)]
	public float speed = 1f;
	[Range(0, 360)]
	public float rotateSpeed;


	Vector2 vel;	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
	}

	void FixedUpdate ()
	{
		// space pod thrust
		float x = Input.GetAxis ("Vertical"); 
		if (x != 0) {
			rb.AddForce(transform.up * speed * Mathf.Clamp(x, 0, 1));
		}

		// space pod rotete
		float y = Input.GetAxis ("Horizontal");
		if (y != 0) {
			rb.MoveRotation(rb.rotation - rotateSpeed * Time.fixedDeltaTime * y);
		}

	}
}
