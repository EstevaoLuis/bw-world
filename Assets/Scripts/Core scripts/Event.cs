using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	public float radius = 1f;
	public string endEvent;
	public string startEvent;

	public float animationOffsetX = -1;
	public float animationOffsetY = 2f;

	private int eventState;
	private GameObject animation;

	private CircleCollider2D collider;

	// Use this for initialization
	void Start () {
		collider = GetComponent<CircleCollider2D>();
		collider.radius = radius;
		collider.isTrigger = true;
		if (startEvent != "") { 
			eventState = QuestManager.instance.getEventState (startEvent);
			if (eventState == -1) Destroy (gameObject);
			//Not yet begun
			if(eventState == 0) {
				animation = GameInstance.instance.playAnimation("Dialog",new Vector3(transform.position.x + animationOffsetX, transform.position.y + animationOffsetY , -1f));
			}
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
