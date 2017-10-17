using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour {

	public Audio_General audioGeneral;

	public void SetGeneralVolume(float val) {
		audioGeneral.setVolume (val);
	}
}
