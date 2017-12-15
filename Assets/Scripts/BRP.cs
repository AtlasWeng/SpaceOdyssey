using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BRP : MonoBehaviour {

	public Transform loadingBar;
	public Transform textIndicator;
	public Transform textLoading;
	public float currentAmount;

	// private variables
	private float speed;

	// private reference

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		speed = GameManager.gm.collectTime;

	}
	
	// Update is called once per frame
	void Update ()
	{
		Collecting();
	}

	void Collecting ()
	{
		if (currentAmount < 100) {
			currentAmount += 100 / speed * Time.deltaTime;
			textIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
				textLoading.gameObject.SetActive(true);
			} else {
				textLoading .gameObject.SetActive(false);
				textIndicator.GetComponent<Text>().text = "Done!";
			}

		loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
	}

	public void ResetBar(){
		currentAmount = 0;
		gameObject.SetActive(false);
	}
}

