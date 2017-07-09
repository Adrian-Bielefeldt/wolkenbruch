using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
	public GameHandler GH;
	public SoundHandler SH;
	public GameObject pause_menu;
	public Button generalVolumeButton;
	public InformationPanel informationPanel;
	public Helper helper;

	public Button minigameButton;
	public Button quizButton;

	public Slider volumeSlider;

	private string mutedString = "Laut schalten";
	private string unmutedString = "Stummschalten";

	private bool mute;
	private bool musicMute;

	void Awake () {
		helper.currentHelp = "Sieh dich in der Szene um. Kannst du noch etwas finden, auf das du noch nicht geklickt hast?";
		SH.SetGeneralVolume (NavigatorData.volume);
		volumeSlider.value = NavigatorData.volume;
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
	}

	public void MainSliderUpdate(float val) {
		Debug.Log ("Volume now: " + val);
		NavigatorData.volume = val;
		if (!mute) {
			SH.SetGeneralVolume(val);
		}
	}

	public void ToggleSound() {
		if (mute) {
			mute = false;
			generalVolumeButton.GetComponentInChildren<Text> ().text = unmutedString;
			SH.SetGeneralVolume (NavigatorData.volume);
		} else {
			mute = true;
			generalVolumeButton.GetComponentInChildren<Text> ().text = mutedString;
			SH.SetGeneralVolume (0f);
		}
	}

	public void DisplayInformation(string title, List<string> pages) {
		informationPanel.setPages (title, pages);
	}

	public void displayMinigameButton(bool state) {
		minigameButton.gameObject.SetActive (state);
	}

	public void displayQuizButton(bool state) {
		quizButton.gameObject.SetActive (state);
	}
}