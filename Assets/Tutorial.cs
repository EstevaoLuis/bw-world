using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public string tutorialName = "Sample";

	private bool isActivated = false;

	void OnTriggerEnter2D(Collider2D other) {
		if(!isActivated && other.gameObject.tag == "Player") {
			UserInterface.instance.showTutorial(tutorialName);
			isActivated = true;
		}
	}

}
