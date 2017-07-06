using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	//----------------------------------------
	// handles
	public UIHandler UH;

	public void chapter(int scene) {
		SceneManager.LoadScene (scene);
	}
}
