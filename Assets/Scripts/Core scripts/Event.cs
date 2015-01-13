using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	public float radius = 1f;
	public string endEvent;
	public string startEvent;

	public float animationOffsetX = -1;
	public float animationOffsetY = 2f;

	public string beforeMessage;
	public string duringMessage;
	public string afterMessage;

	private GameObject animation;

	private CircleCollider2D collider;
	private float controlPeriod = 3f;
	private float lastCheck;

	// Use this for initialization
	void Start () {
		collider = GetComponent<CircleCollider2D>();
		collider.radius = radius;
		collider.isTrigger = true;
	}

	void Update() {
		if(Time.time > lastCheck + controlPeriod) {
			int eventState;
			if(endEvent != "") {
				eventState = QuestManager.instance.getEventState (endEvent);
				if(eventState == 1 && animation == null) {
					animation = GameInstance.instance.playAnimation("Dialog",new Vector3(transform.position.x + animationOffsetX, transform.position.y + animationOffsetY , -1f));
				}
			}
			/*
			if(startEvent != "") {
				eventState = QuestManager.instance.getEventState (startEvent);
			}
			*/
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			if(endEvent != "") {
				QuestManager.instance.endEvent(endEvent);

			}
			if(startEvent != "") {
				QuestManager.instance.startEvent(startEvent);
				Destroy (animation);
			}
		}
	}
}
