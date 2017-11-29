using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BRP : MonoBehaviour {
	public GameObject uibar;
	
	public bool actived = false;
	public Transform loadingBar;
	public Transform textIndicator;
	public Transform textLoading;
	public float currentAmount;
	public float speed;

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (actived) {
			if (currentAmount < 100) {
//				currentAmount += speed * Time.deltaTime;
				textIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
				textLoading.gameObject.SetActive(true);
			} else {
				textLoading .gameObject.SetActive(false);
				textIndicator.GetComponent<Text>().text = "Done!";
			}
		}


		loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
	}
}
