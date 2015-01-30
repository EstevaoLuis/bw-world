using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	public float radius = 1f;
	public string endEvent;
	public string startEvent;

	public bool showAnimation = true;

	public float animationOffsetX = -1;
	public float animationOffsetY = 2f;

	public string beforeMessage;
	public string duringMessage;
	public string afterMessage;

	private GameObject animation;

	private CircleCollider2D collider;
	private float controlPeriod = 5f;
	private float lastCheck;

	private int storyLevel1, storyLevel2;
	private GameObject textObject;
	private int textStatus = -1;
	private Vector3 textPosition;
	private FadeObjectInOut fadingText;
	private bool isCentered = false;


	// Use this for initialization
	void Start () {
		collider = GetComponent<CircleCollider2D>();
		collider.radius = radius;
		collider.isTrigger = true;
		if(startEvent != null) storyLevel2 = QuestManager.instance.getEventStoryLevel (startEvent);
		if (endEvent != null) storyLevel1 = QuestManager.instance.getEventStoryLevel (endEvent);
		else storyLevel2 = storyLevel1;

		textPosition = new Vector3 (transform.position.x, transform.position.y + collider.bounds.size.y, -1f);
	}

	void Update() {
		if (!isCentered && textObject!=null) {
			textObject.transform.position = new Vector3(textObject.transform.position.x - (textObject.renderer.bounds.size.x / 2f),textObject.transform.position.y + (textObject.renderer.bounds.size.y) - 0.5f, -1f);
			isCentered = true;
			textObject.SetActive (false);
		}

		if(Time.time > lastCheck + controlPeriod) {
			int eventState;
			if(showAnimation && animation == null) {
				if((endEvent == "" || endEvent == null) && startEvent != "") {
					eventState = QuestManager.instance.getEventState (startEvent);
					if(eventState == 0) {
						animation = GameInstance.instance.playAnimation("Dialog",new Vector3(transform.position.x + animationOffsetX, transform.position.y + animationOffsetY , -1f));
					}
				}
				else if(endEvent != ""){
					eventState = QuestManager.instance.getEventState (endEvent);
					if(eventState == 1) {
						animation = GameInstance.instance.playAnimation("Dialog",new Vector3(transform.position.x + animationOffsetX, transform.position.y + animationOffsetY , -1f));
					}
				}
			}

			//Before
			if(textStatus != 0 && QuestManager.instance.getStoryLevel() < storyLevel1-1) {
				textStatus = 0;
				if(textObject != null) Destroy(textObject);
				textObject = GameInstance.instance.showNPCText (beforeMessage, textPosition);
				fadingText = textObject.GetComponent("FadeObjectInOut") as FadeObjectInOut;
				isCentered = false;
			}
			//During
			else if(textStatus != 1 && QuestManager.instance.getStoryLevel() == storyLevel2-1) {
				if(textObject != null) Destroy(textObject);
				textStatus = 1;
				textObject = GameInstance.instance.showNPCText (duringMessage, textPosition);
				Debug.Log (textPosition);
				fadingText = textObject.GetComponent("FadeObjectInOut") as FadeObjectInOut;
				isCentered = false;
			}
			//After
			else if(textStatus != 2 && QuestManager.instance.getStoryLevel() >= storyLevel2) {
				if(textObject != null) Destroy(textObject);
				textStatus = 2;
				textObject = GameInstance.instance.showNPCText (afterMessage, textPosition);
				//Debug.Log (textPosition);
				fadingText = textObject.GetComponent("FadeObjectInOut") as FadeObjectInOut;
				isCentered = false;
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
			if(textObject != null) {
				textObject.SetActive (true);
				fadingText.FadeIn (1);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && textObject!=null) {
			textObject.SetActive (true);
			fadingText.FadeOut (1);
		}
	}
}
