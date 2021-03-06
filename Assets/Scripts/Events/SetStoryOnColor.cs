﻿using UnityEngine;
using System.Collections;

public class SetStoryOnColor : MonoBehaviour {
	
	public string endEvent;
	public string startEvent;

	private Colour controller;
	private bool isActivated = false;

	void Start() {
		controller = GetComponent<Colour>();
	}

	// Update is called once per frame
	void Update () {
		if (!isActivated && controller.isColored()) {
			if(endEvent != "" && startEvent != "") {
				bool status = QuestManager.instance.endEvent(endEvent);
				if(status) {
					QuestManager.instance.startEvent(startEvent);
					isActivated = true;
				}
			}
		}
	}
}
