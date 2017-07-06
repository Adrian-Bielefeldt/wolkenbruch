using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour {

	public GameHandler GH;

	public UIHandler UH;

	// Use this for initialization
	void Start () {
		if (NavigatorData.unlockedScenes [2]) {
			UH.helper.currentHelp = "Du kannst jedes Kapitel nochmal spielen, um mehr Punkte zu erreichen.";
		} else {
			UH.helper.currentHelp = "Wähle das erste Kapitel aus, indem du auf den Boden klickst. Die anderen Kapitel wirst du später freischalten. Klicke auf diese Sprechblase, um sie zu schließen.";
			UH.helper.help (UH.helper.currentHelp);
		}
	}
}
