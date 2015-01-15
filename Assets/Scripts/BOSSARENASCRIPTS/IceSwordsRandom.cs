using UnityEngine;
using System.Collections;

public class IceSwordsRandom : MonoBehaviour {

	public GameObject IceSwords;
	//public GameObject iceBomb;
	public GameObject target;
	private GameObject aux;
	private float trigger = 0;
	private float timer = 2;
	private float timer_2 = 7f;
	private float speed = 4f;
	//private float timer_2 = 2f;
	private int nam;
	private int pos = 1;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	void random_generator_ice_sword(){

		Vector3 random_pos = new Vector3 (Random.Range (-5 + target.transform.position.x, target.transform.position.x + 5)
		                                  , Random.Range (-5 + target.transform.position.y, target.transform.position.y + 5));


		aux = (GameObject)Instantiate (IceSwords,random_pos, transform.rotation);
		aux.rigidbody2D.velocity = (Vector3.left + Vector3.down) * speed;


		}
	

//	void OnCollisionEnter2D (Collision2D other){
//		
//		if (other.gameObject.tag == "Player") {
//			trigger = 1;		
//		}
//	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Player") {
			trigger = 1;
		}

	}

	void start_shooting(){
		Invoke("random_generator_ice_sword",timer);
		timer = timer + 1;
	}

//	void onSight(){
//		float dis = Vector3.Distance(transform.position,target.transform.position);
//		if( dis < 5){
//			random_generator_ice_sword();
//		}
//
//	}

	// Update is called once per frame
	void Update () {

	if (trigger == 1) {
			start_shooting();
		}

	}
}

