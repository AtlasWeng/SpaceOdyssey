using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	// the Parameter of the asteroid
	[Header ("Asteroid")]
	public float speedMin;
	public float speedMax;
	public float rotateSpeedMin;
	public float rotateSpeedMax;


	// the reference to the component or other scipt
	private Rigidbody2D rg;
	private bool asteroidStart = false;

	// private parameter
	private float speed;
	private float rotateSpeed;
	private float xDirection;
	private float yDirection; 

	// Use this for initialization
	void Start ()
	{
		// get reference automatically
		rg = GetComponent<Rigidbody2D> ();

		float direction = Random.Range (-1, 1); // give the asteroids random direction of rotation.
		rotateSpeed = Random.Range (rotateSpeedMin, rotateSpeedMax) * Mathf.Sign (direction);
		speed = Random.Range (speedMin, speedMax + 1);
		List<int> list = new List<int> ();
		list.Add (-1);
		list.Add (1);
		xDirection = list [Random.Range (0, 2)];
		yDirection = list [Random.Range (0, 2)];
		Mathf.Round (Random.Range (-1f, 1));
//		Debug.Log(xDirection + "," + yDirection);

	}

	void Update ()
	{
	}


	// rotate the asteroids
	void FixedUpdate ()
	{
		if (!asteroidStart && GameManager.gm.gameStart)
		{
				rg.velocity = new Vector2 (xDirection, yDirection) * speed;
				asteroidStart = true;
		} 

		// Let Asteroid Rotate
		rg.MoveRotation (rg.rotation + rotateSpeed * Time.fixedDeltaTime); 
	}

}
