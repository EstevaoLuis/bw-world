using UnityEngine;
using System.Collections;

public class SetStoryOnDeath : MonoBehaviour {
	
	public string endEvent;
	public string startEvent;

	private EnemyController controller;
	private bool isActivated = false;

	void Start() {
		controller = GetComponent<EnemyController>();
	}

	// Update is called once per frame
	void Update () {
		if (!isActivated && controller.getHealth()<=0) {
			if(endEvent != "") {
				QuestManager.instance.endEvent(endEvent);
				
			}
			if(startEvent != "") {
				QuestManager.instance.startEvent(startEvent);
			}
			isActivated = true;
		}
	}
}
