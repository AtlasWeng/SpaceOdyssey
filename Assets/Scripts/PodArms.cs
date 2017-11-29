using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodArms : MonoBehaviour {
	private bool collected = false;
	private Poole poole;
	private BRP brp;
	// define the timer
	public float collectTime = 3;

	// Use this for initialization
	void Start () {
		poole = GameObject.FindObjectOfType<Poole>();
		brp = GameObject.FindObjectOfType<BRP>();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{

	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (Input.GetKey (KeyCode.Z) && collider.CompareTag ("Target")) {
			collectTime -= Time.deltaTime;
			brp.gameObject.SetActive(true);
			brp.actived = true;
			brp.currentAmount += brp.speed * Time.deltaTime;
			if (collectTime <= 0) {
				collected = true;
			} else {
				brp.gameObject.SetActive(false);
			}
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if (collected) {
			Destroy (poole.rg); // Destroy the rigidbody of poole.
			poole.transform.parent = this.GetComponentInParent<SpacePod> ().transform;
			collected = true;
		}
	}
}
