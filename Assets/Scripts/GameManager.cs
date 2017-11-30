using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	// Static Reference
	public static GameManager gm;

	// Game performance
	[Header("Game Performance")]
	public float gameStartCounting = 3;
	public bool gameStart =false;
	public bool asteroidStart = false;

	[Header("Player Control")]
	public float collectTime = 3f;

	// UI Elements to control
	[Header("UI")]
	public Text UITime;
	public Text UIGameStartCounting;

	// Spawn Point to control
	[Header("Asteroids")]


	// private variables
	private float gameTime = 0;

	// Attach Game Manager
	void Awake ()
	{
		if (gm == null) {
			gm = this.GetComponent<GameManager>();
		}
	}
	// Use this for initialization
	IEnumerator Start ()
	{
		while (gameStartCounting >= 0) {
			UIGameStartCounting.text = gameStartCounting.ToString();
			gameStartCounting --;
			yield return new WaitForSeconds(1);
		}
		UIGameStartCounting.text = "Start";
		yield return new WaitForSeconds(1);
		UIGameStartCounting.gameObject.SetActive(false);
		gameStart = true;

}

	// check all variables
	void CheckDefaults ()
	{
		// friendly error message
		if (UITime == null) {
			Debug.Log ("Need to set UITime on Game Manager");
		} 

		if (UIGameStartCounting == null) {
			Debug.Log("Need to set UIGameStartCounting on Game Manager");
		}
	}

	// Update is called once per frame
	void Update ()
	{
		CheckDefaults();
		Timer ();
		print (gameStartCounting);
	}

	void Timer ()
	{
		if (gameStart){
			gameTime += Time.deltaTime;
			UITime.gameObject.SetActive(true);
			UITime.text = gameTime.ToString("F2");
		}
	}
}
