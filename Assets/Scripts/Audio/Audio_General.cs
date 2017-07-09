using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_General : MonoBehaviour {

	void Start() {
		setVolume (NavigatorData.volume);
	}

	public void setVolume(float volume) {
		foreach (AudioSource source in this.GetComponentsInChildren<AudioSource>()) {
			source.volume = volume;
		}
	}
}
