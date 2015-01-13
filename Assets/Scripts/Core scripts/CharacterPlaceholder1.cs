using UnityEngine;
using System.Collections;

public class CharacterPlaceholder : MonoBehaviour {

	public GameObject characterPrefab;
	public string enemyName;
	public int storyLevel;

	private float checkInterval = 3f;
	private float lastCheck;
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastCheck + checkInterval) {
			if(QuestManager.instance.getStoryLevel() >= storyLevel) {
				GameObject.Instantiate(characterPrefab,transform.position,new Quaternion(0f,0f,0f,1f));
				Destroy(gameObject);
			}
		}
	}
}
