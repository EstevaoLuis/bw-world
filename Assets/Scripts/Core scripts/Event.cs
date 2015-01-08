using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	public float radius = 3f;
	public string endEvent;
	public string startEvent;


	private CircleCollider2D collider;

	// Use this for initialization
	void Start () {
		collider = GetComponent<CircleCollider2D>();
		collider.radius = radius;
		collider.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			if(endEvent != "") {
				QuestManager.instance.endEvent(endEvent);
			}
			if(startEvent != "") {
				QuestManager.instance.startEvent(startEvent);
			}
		}
	}
}
