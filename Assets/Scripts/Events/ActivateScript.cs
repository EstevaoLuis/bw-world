using UnityEngine;
using System.Collections;

public class ActivateScript : MonoBehaviour {

	public int storyLevel; 
	public MonoBehaviour script;


	private float controlPeriod = 3f;
	private float lastCheck;
	private bool isActivated = false;

	// Use this for initialization
	void Awake () {
		script.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActivated && Time.time > lastCheck + controlPeriod) {
			if(QuestManager.instance.getStoryLevel() >= storyLevel) {
				script.enabled = true;
				isActivated = true;
				this.enabled = false;
			}
			lastCheck = Time.time;
		}
	}
}
