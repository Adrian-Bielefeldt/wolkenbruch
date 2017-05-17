using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	//----------------------------------------
	// handles
	public UIHandler UH;

	//-----------------------------------------
	// function definitions
	public void chapter(string scene) {
		SceneManager.LoadScene (scene);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
