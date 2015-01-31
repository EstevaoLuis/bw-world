using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public string tutorialName = "Sample";
	public int storyLevel = 0;

	private bool isActivated = false;

	void OnTriggerEnter2D(Collider2D other) {
		if(!isActivated && other.gameObject.tag == "Player" && QuestManager.instance.getStoryLevel() >= storyLevel) {
			if(Settings.isMobile) tutorialName = tutorialName + "M";
			UserInterface.instance.showTutorial(tutorialName);
			isActivated = true;
		}
	}

}
