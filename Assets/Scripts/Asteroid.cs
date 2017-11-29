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
	private LevelManager levelManager;
	private Rigidbody2D rg;

	// private parameter
	private float speed;
	private float rotateSpeed;
	private float xDirection;
	private float yDirection; 

	// Use this for initialization
	void Start () {
		// get reference automatically
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		rg = GetComponent<Rigidbody2D>();

		float direction = Random.Range(-1, 1); // give the asteroids random direction of rotation.
		rotateSpeed = Random.Range(rotateSpeedMin, rotateSpeedMax) * Mathf.Sign(direction);
		speed = Random.Range(speedMin, speedMax + 1);
		List<int> list = new List<int>();
		list.Add(-1);
		list.Add(1);
		xDirection = list [Random.Range(0, 2)];
		yDirection = list [Random.Range(0, 2)];
		Debug.Log(xDirection + "," + yDirection);

	}

	// Lose Collision
	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.CompareTag("Player")){
			levelManager.LoadLevel("GameOverScene");
		}
	}

	void Update ()
	{
//		gameObject.transform.position = gameObject.transform.position
//		+ new Vector3 (xDirection, yDirection, 0)
//		* Time.deltaTime
//		* speed;

		if (gameObject.transform.position.x >= 8) {
			gameObject.transform.position = new Vector3 (-8, gameObject.transform.position.y, 0);
		} else if (gameObject.transform.position.x <= -8) {
			gameObject.transform.position = new Vector3 (8, gameObject.transform.position.y, 0);
		} else if (gameObject.transform.position.y >= 6) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, -6, 0);
		} else if (gameObject.transform.position.y <= -6) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, 6, 0);
		}
	}


	// rotate the asteroids
	void FixedUpdate ()
	{
		rg.AddForce(new Vector2(xDirection, yDirection) * speed);
		rg.MoveRotation(rg.rotation + rotateSpeed * Time.fixedDeltaTime);
	}

}
