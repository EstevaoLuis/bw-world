using UnityEngine;
using System.Collections;

public class IceSwordsRandom : MonoBehaviour {

	public GameObject IceSwords;
	//public GameObject iceBomb;
	public GameObject target;
	private GameObject aux;
	private float timer = 2f;
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

		Vector3 random_pos = new Vector3 (Random.Range (-10 + target.transform.position.x, target.transform.position.x + 10)
		                                  , Random.Range (-10 + target.transform.position.y, target.transform.position.y + 10));


		
		if (Time.time > timer) {
			aux = (GameObject)Instantiate (IceSwords,random_pos, transform.rotation);
			aux.rigidbody2D.velocity = (Vector3.left + Vector3.down) * speed;
			timer = timer + 2f;

		}
//		if (Time.time > timer_2) {
//			Instantiate (iceBomb, aux.transform.position, transform.rotation);
//			timer_2 = timer_2 + 7f;
//		}
//		if (Time.time > timer_2) {
//			Instantiate (iceBomb, aux.transform.position, transform.rotation);
//			timer_2 = timer_2 + 5f;
//		}

//		Instantiate (IceSwords,random_pos, transform.rotation);
//		aux.name = pos.ToString ();
//		aux.rigidbody2D.velocity = (Vector3.left + Vector3.down) * speed;
//		pos++;

		//nam = nam - 1;

	}

	// Update is called once per frame
	void Update () {

		random_generator_ice_sword ();

	}
}
//		if (Time.time > timer_2) {
//			DestroyImmediate(aux);
//			timer_2 = timer_2 + 4f;
//
//		}
