using UnityEngine;
using System.Collections;

public class RedCrystalGot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			//GameInstance.instance.movePlayer (new Vector3 (0, 0));
			QuestManager.instance.endEvent("Red Gem");
			GameInstance.instance.moveGameSystem (new Vector3 (0, 0));
			QuestManager.instance.startEvent("Final Boss");
		}
	}

}
