using UnityEngine;
using System.Collections;

public class EnemyPlaceholder : MonoBehaviour {

	public GameObject enemyPrefab;
	public string enemyName;
	public int storyLevel;

	private float checkInterval = 3f;
	private float lastCheck;
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastCheck + checkInterval) {
			if(QuestManager.instance.getStoryLevel() >= storyLevel) {
				GameObject newEnemy = (GameObject) GameObject.Instantiate(enemyPrefab,transform.position,new Quaternion(0f,0f,0f,1f));
				newEnemy.GetComponent<EnemyController>().enemyName = enemyName;
				Destroy(gameObject);
			}
		}
	}
}
