using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter04_handler : MonoBehaviour {

	public float widthOfCollider = 2f;

	public float z_axis = 0f;

	public Helper helper;

	public UIHandler UI;

	string warmHelp = "Wie wirst du nur zu flüssigem Wasser? Vielleicht kannst du dich nur ein bisschen abkühlen, wenn du mit einem kalten Teilchen zusammenstößt.";
	string coldHelp = "Wie wirst du nur zu flüssigem Wasser? Vielleicht kannst du dich nur ein bisschen erwärmen, wenn du mit einem warmen Teilchen zusammenstößt.";

	Vector2 screenSize;

	float startTime;

	bool alreadyWon = false;

	Dictionary<player.aggregateState, bool> reachedStates = new Dictionary<player.aggregateState, bool>() {
		{player.aggregateState.GAS, true},
		{player.aggregateState.LIQUID, false},
		{player.aggregateState.SOLID, false}
	};

	// Use this for initialization
	void Start () {
		startTime = Time.time;

		helper.currentHelp = warmHelp;
		helper.help ("Willkommen in den Wolken. Versuche, alle Aggregatzustände einzunehmen. In den Fallwinden kannst du zu Hagel und in der Sonne zu Wasserdampf werden.");
		Dictionary<string, Transform> colliders = new Dictionary<string, Transform> ();

		colliders.Add ("Top", new GameObject().transform);
		colliders.Add ("Bottom", new GameObject().transform);
		colliders.Add ("Right", new GameObject().transform);
		colliders.Add ("Left", new GameObject().transform);

		Vector3 cameraPos = Camera.main.transform.position;
		screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
		screenSize.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

		foreach (KeyValuePair<string, Transform> bc in colliders) {
			bc.Value.gameObject.AddComponent<BoxCollider2D> ();
			bc.Value.name = bc.Key + "Collider";
			bc.Value.parent = transform;

			if(bc.Key == "Left" || bc.Key == "Right")
				bc.Value.localScale = new Vector3(widthOfCollider, screenSize.y * 2, widthOfCollider);
			else
				bc.Value.localScale = new Vector3(screenSize.x * 2, widthOfCollider, widthOfCollider);
		}

		colliders["Right"].position = new Vector3(cameraPos.x + screenSize.x + (colliders["Right"].localScale.x * 0.5f), cameraPos.y, z_axis);
		colliders["Left"].position = new Vector3(cameraPos.x - screenSize.x - (colliders["Left"].localScale.x * 0.5f), cameraPos.y, z_axis);
		colliders["Top"].position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (colliders["Top"].localScale.y * 0.5f), z_axis);
		colliders["Bottom"].position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (colliders["Bottom"].localScale.y * 0.5f), z_axis);
	}

	public void stateReached(player.aggregateState state) {
		reachedStates [state] = true;
		if (state == player.aggregateState.GAS) {
			helper.currentHelp = warmHelp;
		}
		if (state == player.aggregateState.SOLID) {
			helper.currentHelp = coldHelp;
		}
		foreach (KeyValuePair<player.aggregateState, bool> entry in reachedStates) {
			if (!entry.Value) {
				return;
			}
		}

		if (!alreadyWon) {
			if (Time.time - startTime > 120) {
				NavigatorData.achievedPointsGame [4] = 0;
				helper.currentHelp = "Obwohl es ein Weilchen gedauert hat hast du alle Aggregatzustände erreicht. Jetzt kannst du dich am Quiz versuchen. Klicke auf Quiz links oben, um loszulegen.";
			} else {
				NavigatorData.achievedPointsGame [4] = 4;
				helper.currentHelp = "Gratulation. Du hast sehr schnell alle Aggregatzustände erreicht. Jetzt kannst du dich am Quiz versuchen. Klicke auf Quiz links oben, um loszulegen.";
			}
			helper.help (helper.currentHelp);
			UI.displayQuizButton (true);
		}
		alreadyWon = true;
	}
}
