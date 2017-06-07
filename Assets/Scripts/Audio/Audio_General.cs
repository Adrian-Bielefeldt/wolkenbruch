using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_General : MonoBehaviour {

	public void setVolume(float volume) {
		foreach (AudioSource source in this.GetComponentsInChildren<AudioSource>()) {
			source.volume = volume;
		}
	}
}
