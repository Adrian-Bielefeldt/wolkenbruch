using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class river_choice : MonoBehaviour {

	public chapter02_handler handler;

	public Helper helper;

	public bool wasRight;

	public bool answered;

	public bool finalChoice;

	public void setRight(bool wasRight_, string help) {
		helper.help (help);

		wasRight = wasRight_;
		answered = true;
		handler.notifyRiverGame (finalChoice);
	}
}
