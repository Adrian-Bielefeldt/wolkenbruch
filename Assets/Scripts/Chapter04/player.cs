using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public GameObject solid;
	public GameObject liquid;
	public GameObject gas;

	public GameObject wind;
	public GameObject sun;

	public chapter04_handler handler;

	public enum aggregateState {
		SOLID,
		LIQUID,	
		GAS
	}

	public aggregateState state;

	public bool isPlayer;

	void Start () {
		if (isPlayer) GetComponent<SpriteOutline> ().UpdateOutline (true);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == wind) {
			if (isPlayer) handler.stateReached (aggregateState.SOLID);
			state = aggregateState.SOLID;
			GetComponent<SpriteRenderer> ().sprite = solid.GetComponent<SpriteRenderer> ().sprite;
			GetComponent<PolygonCollider2D> ().points = solid.GetComponent<PolygonCollider2D> ().points;
			return;
		}
		if (other.gameObject == sun) {
			if (isPlayer) handler.stateReached (aggregateState.GAS);
			state = aggregateState.GAS;
			GetComponent<SpriteRenderer> ().sprite = gas.GetComponent<SpriteRenderer> ().sprite;
			GetComponent<PolygonCollider2D> ().points = gas.GetComponent<PolygonCollider2D> ().points;
			return;
		}
	}
		
	void OnCollisionEnter2D(Collision2D collision) {
		player player = collision.collider.gameObject.GetComponent<player> ();
		if (player != null) {
			if ((player.state == aggregateState.SOLID && state == aggregateState.GAS) | (player.state == aggregateState.GAS && state == aggregateState.SOLID)) {
				if (isPlayer || player.isPlayer) handler.stateReached (aggregateState.LIQUID);
				state = aggregateState.LIQUID;
				GetComponent<SpriteRenderer> ().sprite = liquid.GetComponent<SpriteRenderer> ().sprite;
				GetComponent<PolygonCollider2D> ().points = liquid.GetComponent<PolygonCollider2D> ().points;
				player.state = aggregateState.LIQUID;
				player.GetComponent<SpriteRenderer> ().sprite = liquid.GetComponent < SpriteRenderer> ().sprite;
				player.GetComponent<PolygonCollider2D> ().points = liquid.GetComponent<PolygonCollider2D> ().points;
			}
		}
	}
}
