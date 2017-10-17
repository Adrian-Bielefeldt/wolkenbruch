using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour {

	public Text header;
	public Text text;

	public Button nextButton;
	public Button lastButton;

	List<string> pages;

	int currentPage = 0;

	public void deactivate() {
		gameObject.SetActive (false);
	}

	public void setPages(string titel_, List<string> pages_) {
		if (pages_.Count < 1) {
			pages_[0] = "No text was supplied.";
		}

		currentPage = 0;

		pages = pages_;

		header.text = titel_;
		text.text = pages [currentPage];

		checkNextAndLastPage ();

		gameObject.SetActive (true);
	}

	void checkNextAndLastPage() {
		if (currentPage <= 0) {
			lastButton.gameObject.SetActive (false);
		} else {
			lastButton.gameObject.SetActive (true);
		}

		if (currentPage >= pages.Count - 1) {
			nextButton.gameObject.SetActive (false);
		} else {
			nextButton.gameObject.SetActive (true);
		}
	}

	public void nextPage () {
		currentPage++;
		text.text = pages [currentPage];
		checkNextAndLastPage ();
	}

	public void lastPage () {
		currentPage--;
		text.text = pages [currentPage];
		checkNextAndLastPage ();
	}

}
