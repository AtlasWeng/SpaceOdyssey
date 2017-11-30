using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {
	// Array of object to spawn
	public GameObject[] asteroids;

	// Time it takes to spawn asteroids
	[Space(3)]
	public float waitingForNextSpawn = 10;
	public float theCountdown = 10;

	// the range of x
	[Header ("X Spawn Range")]
	public float xMin;
	public float xMax;

	// the range of y
	[Header ("Y Spawn Range")]
	public float yMin;
	public float yMax;

	[Header ("Number Of object")]
	public float Number;


	public List<GameObject> AsteroidList;
	// Use this for initialization
	void Start ()
	{
		if (asteroids == null) {
			Debug.Log("Need to set GameObject on AsteroidSpawn");
		}
	}
	
	// Update is called once per frame
	void Update () {
		// timer to spawn the next asteroid
		theCountdown -= Time.deltaTime;
//		if (theCountdown <= 0) {
		while (Number >= 0){
			SpawnAsteroids();
			Number --;
			theCountdown = waitingForNextSpawn;
		}
	}

	void SpawnAsteroids() {
		// Defines the min and max ranges for x and y
		Vector3 pos = new Vector3 (Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0);

		// Choose a new asteroid to spawn from the array
		GameObject asteroidPrefab = asteroids [Random.Range(0, asteroids.Length)];

		// Create random asteroid at random position
		GameObject asteroid = Instantiate (asteroidPrefab, pos, transform.rotation);
		AsteroidList.Add(asteroid);
		print (AsteroidList);
	}
}
