using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poole : MonoBehaviour {
	public Rigidbody2D rg;
	public CircleCollider2D cc2D;

	// the range of x
	public float xMax;
	public float xMin;

	// the range of y
	public float yMax;
	public float yMin;

	// track the play state
	public bool collected = false;
	public bool _isBounce = false;

	// set reference to the component
	Animator _animator;

	void Awake(){
		rg = GetComponent<Rigidbody2D>();
		gameObject.transform.position = new Vector3 (Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
		_animator = GetComponent<Animator>();
		cc2D = GetComponent<CircleCollider2D>();
	}

	public void Start(){
		Vector2 iniSpeed = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
		rg.velocity = iniSpeed;
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		_isBounce = true;
	}

	void OnCollisionExit2D (Collision2D collision)
	{
		_isBounce = false;
	}

	void Update(){
		_animator.SetBool("Collected", collected);
		_animator.SetBool("Bounce", _isBounce);
	}
}
