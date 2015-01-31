using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderGenerator : MonoBehaviour {

	public int maxSpiders = 20;
	public GameObject door;
	private GameObject player;
	private int spidersGenerated = 0;
	private int spidersKilled = 0;
	private float lastGeneration = 0f;
	private bool isActive = false;
	private GameObject spider;
	public GameObject camera;
	public bool trigger = true;
	private bool isCompleted = false;
	public float area = 2f;

	private IList spiders = new List<GameObject>();

	// Use this for initialization
	void Start () {
		spider = Resources.Load ("Enemies/Spider") as GameObject;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			if (spidersGenerated < 5 && (lastGeneration == 0f || Time.time > lastGeneration + 3f)) {
					instantiateSpider ();
					spidersGenerated++;
					lastGeneration = Time.time;
			} else if (spidersGenerated >= 5 && spidersGenerated < maxSpiders && Time.time > lastGeneration + 1f) {
					instantiateSpider ();
					spidersGenerated++;
					lastGeneration = Time.time;
			}
			if(!isCompleted) checkSpiders ();
		}
	}

	void instantiateSpider() {
		Vector3 newPosition = new Vector3 (transform.position.x + Random.Range(-area,+area), transform.position.y + Random.Range(-area,+area), 0f);
		GameObject newSpider = (GameObject) Instantiate(spider, newPosition, Quaternion.Euler(new Vector3(0,0,0)));
		GameInstance.instance.playAnimation ("Appear", new Vector3(transform.position.x,transform.position.y,0.1f));
		GameInstance.instance.playAudio ("Darkness6");
		int randType = Random.Range (0, 2);
		if(randType > 0) (newSpider.GetComponent ("EnemyController") as EnemyController).enemyName = "Spider (Noob)";
		else (newSpider.GetComponent ("EnemyController") as EnemyController).enemyName = "Spider";
		spiders.Add (newSpider);
		GameInstance.instance.playAudio ("Darkness6");
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.gameObject.tag);
		if(other.gameObject.tag == "Player") {
			isActive = true;
		}
	}

	void checkSpiders(){
		bool deadSpiderFound = false;
		GameObject ragno = null;
		foreach (GameObject arana in spiders) {
			if (arana == null){
				spidersKilled++;
				ragno = arana;
				deadSpiderFound = true;
				break;
			}
		}

		if (deadSpiderFound)
			removeSpider(ragno);

		if (spidersKilled == maxSpiders) {

			isCompleted = true;
			//settingCamera();
			if(trigger == true){
				settingCamera();
			}
			if(trigger == false){
				DestroyingDoor();
			}
		}
	}
	void DestroyingDoor(){
		GameInstance.instance.playAudio("Magic3");
		Destroy(door);
		Destroy(this);
	}
	void settingCamera(){

		Instantiate (camera, player.transform.position, transform.rotation);
		Invoke ("DestroyingDoor", 4);

	}

	public bool getTrigger(){
		return trigger;
	}
	void removeSpider(GameObject ragno){
		spiders.Remove (ragno);
	}


}
