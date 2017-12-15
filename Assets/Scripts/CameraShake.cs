using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	public float shakeTime;
	public float shakeAmount;

	Vector3 startPos;

	void Start(){
		startPos = transform.position;
	}

	void Update ()
	{

	}

	void FixedUpdate ()
	{
		if (shakeTime > 0) {
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x + ShakePos.x, 
				transform.position.y + ShakePos.y,
				transform.position.z);
			shakeTime -= Time.deltaTime;
		} else {
			transform.position = startPos;
		}
	}

	public void Shake(float shakePwr, float shakeDur){
		shakeAmount = shakePwr;
		shakeTime = shakeDur;
	}
}
