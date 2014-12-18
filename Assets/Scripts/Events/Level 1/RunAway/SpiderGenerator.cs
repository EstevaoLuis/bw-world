using UnityEngine;
using System.Collections;

public class SpiderGenerator : MonoBehaviour {

	private int spidersGenerated = 0;
	private float lastGeneration = 0f;

	private GameObject spider;

	// Use this for initialization
	void Start () {
		spider = Resources.Load ("Enemies/Spider") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(spidersGenerated<5 && Time.time > lastGeneration + 5f) {
			instantiateSpider();
			spidersGenerated++;
			lastGeneration = Time.time;
		}
		else if(spidersGenerated>=5 && spidersGenerated<20 && Time.time > lastGeneration + 2f) {
			instantiateSpider();
			spidersGenerated++;
			lastGeneration = Time.time;
		}
	}

	void instantiateSpider() {
		GameObject newSpider = (GameObject) Instantiate(spider, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
		(newSpider.GetComponent ("EnemyController") as EnemyController).name = "Spider (Noob)";
		Debug.Log ("Spider!");
	}
}
