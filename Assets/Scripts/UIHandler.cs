using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
	public GameHandler GH;
	public SoundHandler SH;
	public GameObject pause_menu;

	private bool mute;

	private float volume;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update () {
		ScanForKeyStroke();
	}

	void ScanForKeyStroke() {
		if (Input.GetKeyDown("escape")) TogglePauseMenu();
	}

	public void TogglePauseMenu()
	{
		// not the optimal way but for the sake of readability
		if (pause_menu.activeSelf)
		{
			pause_menu.SetActive (false);
			Time.timeScale = 1.0f;
		}
		else
		{
			pause_menu.SetActive (true);
			Time.timeScale = 0f;
		}

		Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
	}

	//-----------------------------------------------------------
	// Music Settings Function Definitions
	public void MusicSliderUpdate(float val) {
		volume = val;
		if (!mute) {
			SH.SetVolume(val);
		}
	}

	public void ToggleSound() {
		if (mute) {
			mute = false;
			SH.SetVolume (volume);
		} else {
			mute = true;
			SH.SetVolume (0f);
		}
	}
}