using UnityEngine;
using System.Collections;

public class returningCamera : MonoBehaviour {

	//public int setStoryLevel;
	public string endEvent = "";
	public string startEvent = "";
	public float activateAfterTime = 3f;
	private bool isActivated = false;

	//public GameObject fadeInOut;
//	public GameObject r = null;
	private GameObject Cam = null;
	private int trigger = 0;
	private int trigger_2 = 0;
	public Vector3 desirePosition;
	private GameObject player;
	private PlayerController pl;
	private Camera cameratofade;
	private float timer;


	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");
		pl = player.GetComponent <PlayerController> ();

		Cam = GameObject.Find ("Camera");
		cameratofade = Cam.GetComponent<Camera> ();


	}
	void update(){

		Cam = GameObject.Find ("Camera");
		cameratofade = Cam.GetComponent<Camera> ();

		if (cameratofade == null) {

			cameratofade = Camera.main;
		}
//		Cam = GameObject.Find ("Camera");
//		cameratofade = Cam.GetComponent<Camera> ();

	}


	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Player" && !isActivated) {
			Invoke ("off",activateAfterTime);
			isActivated = true;
		}

	}
	

	void lights_on(){

		cameratofade.enabled = true;

	}
	void off(){
		if (cameratofade.enabled == true) {
					cameratofade.enabled = false;
					pl.isAvailable (false);
					GameInstance.instance.movePlayer (desirePosition);
					GameInstance.instance.moveCamera (desirePosition);
					Invoke ("on", 3);
				}

	}
	void on(){
		
		cameratofade.enabled = true;
		pl.isAvailable (true);

		if (endEvent != "") QuestManager.instance.endEvent (endEvent);
		//if (setStoryLevel > 0) QuestManager.instance.setStoryLevel (setStoryLevel);
		if (startEvent != "") QuestManager.instance.startEvent (startEvent);
		//cameratofade.enabled = true;
		
	}
	

}
