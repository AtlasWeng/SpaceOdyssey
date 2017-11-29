using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name)
	{
		Debug.Log("Load level = " + name);
		SceneManager.LoadScene(name);
	}

}
