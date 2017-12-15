using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodArms : MonoBehaviour {
	// public variables

	// private variables
	private float t;
	private BRP brp;
	private Poole poole;

	void Awake(){
		// get reference to the component
		brp = GameObject.FindObjectOfType<BRP>();
		if(brp==null) // if UI Indicator is missing
			Debug.LogError("'BRP' script is missing");

		poole = GameObject.FindObjectOfType<Poole>();
		if(poole==null) // if gameObject is missing
			Debug.LogError("'Poole' script is missing");

		t = GameManager.gm.collectTime; //collect timer
	}

	// Use this for initialization
	void Start () {
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (Input.GetKey (KeyCode.Z) && collider.CompareTag ("Target") && !poole.collected) {
				t -= Time.deltaTime;
				brp.gameObject.SetActive(true);
				//Debug.Log("Collecting: " + t);

				if (t <= 0) 
				{
					poole.collected = true;
					Destroy (poole.rg); // Destroy the rigidbody of poole.
					poole.cc2D.isTrigger = true;
//					Destroy (poole.cc2D);
					poole.transform.parent = this.GetComponentInParent<SpacePod> ().transform;
					//Debug.Log("Done!");
				}
		} else if (Input.GetKeyUp(KeyCode.Z)) {
			t = GameManager.gm.collectTime;
			brp.ResetBar();
			//Debug.Log("t: " + t + ", original collect time: " + GameManager.gm.collectTime);
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		t = GameManager.gm.collectTime;
		brp.ResetBar();
	}


}
