using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour {

	public Vector2 newPosition;

	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			GameInstance.instance.movePlayer(new Vector3(newPosition.x, newPosition.y, 0f));
			GameInstance.instance.moveCamera(new Vector3(newPosition.x, newPosition.y, 0f));
			QuestManager.instance.setStoryLevel(6);
			QuestManager.instance.startEvent("Village under attack");
		}
	}
}
