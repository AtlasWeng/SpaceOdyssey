using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodArms : MonoBehaviour {

	// private variables
	private float t;
	private bool collected = false;
	private BRP brp;
	private Poole poole;

	// Use this for initialization
	void Start () {
		//make the references
		brp = GameObject.FindObjectOfType<BRP>();
		poole = GameObject.FindObjectOfType<Poole>();

		t = GameManager.gm.collectTime; //Restore the timer
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (Input.GetKey (KeyCode.Z) && collider.CompareTag ("Target")) {
			if (!collected) 
			{
				t -= Time.deltaTime;
				brp.gameObject.SetActive(true);
				//Debug.Log("Collecting: " + t);

				if (t <= 0) 
				{
					collected = true;
					Destroy (poole.rg); // Destroy the rigidbody of poole.
					poole.transform.parent = this.GetComponentInParent<SpacePod> ().transform;
					//Debug.Log("Done!");
				}
			} 
		} else if (Input.GetKeyUp(KeyCode.Z)) {
			t = GameManager.gm.collectTime;
			brp.ResetBar();
			//Debug.Log("t: " + t + ", original collect time: " + GameManager.gm.collectTime);
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		brp.ResetBar();
	}


}
