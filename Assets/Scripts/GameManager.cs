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
	public float gameTime = 60;

	// UI Elements to control
	[Header("UI")]
	public Text UITime;
	public Text UIGameStartCounting;

	// Spawn Point to control
	[Header("SFX")]
	public AudioClip gameOver;

	// store reference
	private LevelManager levelManager;
	public AudioSource _audioSource;

	// Attach Game Manager
	void Awake ()
	{
		if (gm == null) {
			gm = this.GetComponent<GameManager>();
		}

		levelManager = GameObject.FindObjectOfType<LevelManager>();

		_audioSource = this.GetComponent<AudioSource>();
	}
	// Use this for initialization
	IEnumerator Start ()
	{
//		while (gameStartCounting >= 0) {
//			UIGameStartCounting.text = gameStartCounting.ToString();
//			gameStartCounting --;
//			yield return new WaitForSeconds(1);
//		}
		UIGameStartCounting.text = "'SPACE' \nto thrust";
		yield return new WaitForSeconds(2);
		UIGameStartCounting.text = "'Z' \nto collect";
		yield return new WaitForSeconds(2);
		UIGameStartCounting.text = "Don't far away from space station!";
		yield return new WaitForSeconds(2);
		UIGameStartCounting.text = "Save Him & Turn Back!";
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
	}

	void Timer ()
	{
		if (gameStart) {
			if (gameTime >= 20) {
				gameTime -= Time.deltaTime;
			} else if (gameTime > 0 && gameTime < 20) {
				gameTime -= Time.deltaTime;
				UITime.color = Color.red;
				if (!_audioSource.isPlaying) {
					_audioSource.PlayOneShot(gameOver);
				}
			} else if(gameTime <= 0){
				gameTime = 0;
				levelManager.LoadLevel("GameOverScene");
			}
			UITime.gameObject.SetActive(true);
			UITime.text = gameTime.ToString("F2");
		}
	}
}
