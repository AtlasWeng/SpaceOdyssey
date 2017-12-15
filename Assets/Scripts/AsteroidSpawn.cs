using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {
	// Array of object to spawn
	public GameObject[] asteroids;
	public GameObject otherObject;

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
	public int asteroidNumber = 8;
	public int objectNumber = 0;

	// list
	[Header ("List")]
	public List<GameObject> AsteroidList;
	public List<GameObject> ObjectList;

	void Awake(){
		SetupDefaults();
	}

	void Start(){
		SpawnAsteroids();
		SpawnObject();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// use a parameter 'cd' to instantiate object one by one
		// timer to spawn the next asteroid
		// theCountdown -= Time.deltaTime;
		// if (theCountdown <= 0) {

		// create the object
	}

	void SpawnAsteroids ()
	{
		

		// Create random asteroid at random position
		while (asteroidNumber > 0){
			// Defines the min and max ranges for x and y
			Vector3 pos = new Vector3 (Random.Range (xMin, xMax), Random.Range (yMin, yMax), 0);

			// Choose a new asteroid to spawn from the array
			GameObject asteroidPrefab = asteroids [Random.Range (0, asteroids.Length)];

			GameObject asteroid = Instantiate (asteroidPrefab, pos, transform.rotation);
			AsteroidList.Add(asteroid);
			asteroidNumber --;
		}
	}

	void SpawnObject ()
	{
		while (objectNumber > 0) {
			Vector3 pos = new Vector3 (Random.Range (xMin, xMax), Random.Range (yMin, yMax), 0);
			GameObject ast = Instantiate (otherObject, pos, transform.rotation);
			ObjectList.Add(ast);
			objectNumber--;
		}
	}

	void SetupDefaults ()
	{
		// check the instance
		if (asteroids == null) {
			Debug.LogError ("Need to set ASTEROIDS on AsteroidSpawn");
		}

		if (otherObject == null) {
			Debug.LogError ("Need to set OTHER OBJECT on AsteroidSpawn");
		}
	}
}
