using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScene : MonoBehaviour {

	public GameObject logo;

	public GameObject start;

	bool stoppedLogo = false;

	// Update is called once per frame
	void Update () {
		if (!stoppedLogo) {
			if (Time.time > 5) {
				stoppedLogo = true;
				logo.SetActive (false);
				start.SetActive (true);
			}
		}
	}
}
