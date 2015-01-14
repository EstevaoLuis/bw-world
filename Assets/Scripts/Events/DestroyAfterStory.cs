using UnityEngine;
using System.Collections;

public class DestroyAfterStory : MonoBehaviour {

	public int storyLevel;
	public GameObject replaceWith;

	private float controlPeriod = 3f;
	private float lastCheck = 0f;


	void Update() {
		if(Time.time > lastCheck + controlPeriod) {
			if(QuestManager.instance.getStoryLevel() >= storyLevel) {
				if(replaceWith != null) GameObject.Instantiate(replaceWith, transform.position, transform.rotation);
				Destroy(gameObject);
			}
			lastCheck = Time.time;
		}
	}

}
