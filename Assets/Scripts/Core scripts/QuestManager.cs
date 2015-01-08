using UnityEngine;
using System.Collections;
using SimpleJSON;

public class QuestManager : MonoBehaviour {

	private static QuestManager _instance;

	private UserInterface userInterface;
	private bool activeTarget = false;
	private Vector3 currentTarget;
	private GameObject player;
	private JSONNode events;
	private string currentEvent;
	private int storyLevel;

	//Instance management
	public static QuestManager instance
	{
		get
		{	
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			_instance = this;

			userInterface = GameObject.FindWithTag ("UserInterface").GetComponent("UserInterface") as UserInterface;
			player = GameObject.FindWithTag ("Player") as GameObject;

			TextAsset eventsJson = Resources.Load("EventsDatabase") as TextAsset;
			events = JSONNode.Parse(eventsJson.text);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(activeTarget) {
			float distance = Vector3.Distance(currentTarget,player.transform.position);
			if(distance > 5f) {
				userInterface.enableArrowDirection (true);
				float dY = currentTarget.y - player.transform.position.y;
				float dX = currentTarget.x - player.transform.position.x;
				float coefficent = dY/dX;
				float angle = Mathf.Round(Mathf.Atan(coefficent) * (float)(180.0 / Mathf.PI));
				if(dX<0) angle += 180;
				userInterface.setArrowDirection(angle);
			}
			else userInterface.enableArrowDirection (false);
		}
	}

	public void setNewTarget(Vector3 newTarget) {
		activeTarget = true;
		currentTarget = newTarget;
	}

	private void cancelTarget() {
		if(activeTarget) {
			activeTarget = false;
			userInterface.enableArrowDirection (false);
		}
	}

	public bool endEvent(string name) {
		if(events[name] != null && name == currentEvent) {
			currentEvent = "";
			Debug.Log ("Event ended: " + name);
			cancelTarget ();
			GameInstance.instance.increaseExperience(events[name]["experience"].AsInt);
			return true;
		}
		return false;
	}

	public bool startEvent(string name) {
		if (events [name] != null) {
			Debug.Log ("Event started: " + name);
			setNewTarget(new Vector3(events[name]["targetX"].AsFloat,events[name]["targetY"].AsFloat,events[name]["targetZ"].AsFloat));
			currentEvent = name;
			return true;
		}
		return false;
	}

	public int getStoryLevel() {
		return storyLevel;
	}

	public void setStoryLevel(int lv) {
		storyLevel = lv;
	}

}
