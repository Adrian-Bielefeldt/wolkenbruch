using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour {

	public Sprite good;

	public Sprite bad;

	void Start () {
		float maxPoints = 0;
		float achievedPoints = 0;

		for (int i = 1; i <= 4; i++) {
			maxPoints += NavigatorData.maxPointsGame [i];
			maxPoints += NavigatorData.maxPointsQuiz [i];

			achievedPoints += NavigatorData.achievedPointsGame [i];
			achievedPoints += NavigatorData.achievedPointsQuiz [i];
		}

		float part = achievedPoints / maxPoints;

		Debug.Log (achievedPoints);
		Debug.Log (maxPoints);

		Debug.Log (part);

		if (part < 0.1f) {
			GetComponent<SpriteRenderer> ().sprite = bad;
		}
		if (part > 0.8f) {
			GetComponent<SpriteRenderer> ().sprite = good;
		}

	}
}
