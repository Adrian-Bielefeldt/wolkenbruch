using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
	public GameHandler GH;
	public SoundHandler SH;
	public GameObject pause_menu;
	public GameObject generalVolumeButton;
	public GameObject musicVolumeButton;
    public GameObject informationItems;
    public GameObject plusIcons;

	private string mutedString = "Laut schalten";
	private string unmutedString = "Stummschalten";

	private bool mute;
	private bool musicMute;

	private float volume;

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
            plusIcons.SetActive(true);
            informationItems.SetActive(true);
            pause_menu.SetActive (false);
			Time.timeScale = 1.0f;
		}
		else
		{
            plusIcons.SetActive(false);
            informationItems.SetActive(false);
            pause_menu.SetActive (true);
			Time.timeScale = 0f;
		}
	}

	public void MainSliderUpdate(float val) {
		Debug.Log ("Volume now: " + val);
		volume = val;
		if (!mute) {
			SH.SetGeneralVolume(val);
		}
	}

	public void ToggleSound() {
		if (mute) {
			mute = false;
			generalVolumeButton.GetComponentInChildren<Text> ().text = unmutedString;
			SH.SetGeneralVolume (volume);
		} else {
			mute = true;
			generalVolumeButton.GetComponentInChildren<Text> ().text = mutedString;
			SH.SetGeneralVolume (0f);
		}
	}

	public void ToggleMusic() {
		if (musicMute) {
			musicMute = false;
			musicVolumeButton.GetComponentInChildren<Text> ().text = unmutedString;
			SH.SetMusicVolume (volume);
		} else {
			musicMute = true;
			musicVolumeButton.GetComponentInChildren<Text> ().text = mutedString;
			SH.SetMusicVolume (0f);
		}
	}
}