using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Kapitel : MonoBehaviour {

	public GameHandler GH;

	public int chapter;

	public SpriteRenderer emptyStars;

	public SpriteRenderer fullStars;

	bool enabled;

	float pointPercentageAchieved;

	void Start() {
		if (NavigatorData.unlockedScenes[chapter]) {
			GetComponent<SpriteRenderer> ().color = Color.white;
			enabled = true;
		} else {
			GetComponent<SpriteRenderer> ().color = Color.gray;
			enabled = false;
		}
		if (NavigatorData.chapterStarted [chapter]) {
			float maxPoints = NavigatorData.maxPointsGame [chapter];
			maxPoints += NavigatorData.maxPointsQuiz [chapter];

			float achievedPoints = NavigatorData.achievedPointsGame [chapter];
			achievedPoints += NavigatorData.achievedPointsQuiz [chapter];

			pointPercentageAchieved = achievedPoints / maxPoints;
		} else {
			pointPercentageAchieved = 0f;
		}
		updateStars ();
	}

	public void updateStars() {
		if (enabled) {
			emptyStars.gameObject.SetActive (true);

			float difference = emptyStars.size.x - emptyStars.size.x * pointPercentageAchieved;

			fullStars.size = new Vector2 (emptyStars.size.x * pointPercentageAchieved, fullStars.size.y);
			fullStars.transform.position = new Vector3 (emptyStars.transform.position.x - difference / 2, emptyStars.transform.position.y, emptyStars.transform.position.z);
		} else {
			emptyStars.gameObject.SetActive (false);
		}
	}

	void OnMouseDown () {
		if (enabled) {
			NavigatorData.chapterStarted[chapter] = true;
			GH.chapter (chapter);
		}
	}

	void OnMouseEnter () {
		if (enabled) GetComponent<SpriteOutline> ().UpdateOutline (true);
	}

	void OnMouseExit () {
		if (enabled) GetComponent<SpriteOutline> ().UpdateOutline (false);
	}
}
