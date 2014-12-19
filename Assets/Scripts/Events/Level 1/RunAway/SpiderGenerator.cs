using UnityEngine;
using System.Collections;

public class SpiderGenerator : MonoBehaviour {

	private int spidersGenerated = 0;
	private float lastGeneration = 0f;
	private bool isActive = false;
	private GameObject spider;

	// Use this for initialization
	void Start () {
		spider = Resources.Load ("Enemies/Spider") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
				if (spidersGenerated < 5 && (lastGeneration == 0f || Time.time > lastGeneration + 3f)) {
						instantiateSpider ();
						spidersGenerated++;
						lastGeneration = Time.time;
				} else if (spidersGenerated >= 5 && spidersGenerated < 20 && Time.time > lastGeneration + 1f) {
						instantiateSpider ();
						spidersGenerated++;
						lastGeneration = Time.time;
				}
		}
	}

	void instantiateSpider() {
		GameObject newSpider = (GameObject) Instantiate(spider, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
		int randType = Random.Range (0, 2);
		if(randType > 0) (newSpider.GetComponent ("EnemyController") as EnemyController).enemyName = "Spider (Noob)";
		else (newSpider.GetComponent ("EnemyController") as EnemyController).enemyName = "Spider";
		GameInstance.instance.playAudio ("Darkness6");
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.gameObject.tag);
		if(other.gameObject.tag == "Player") {
			isActive = true;
			Debug.Log ("Yeah");
		}
	}
}
