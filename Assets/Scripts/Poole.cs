using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poole : MonoBehaviour {
	public Rigidbody2D rg;

	public void Start(){
		rg = GetComponent<Rigidbody2D>();
	}
}
