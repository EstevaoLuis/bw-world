using UnityEngine;
using System.Collections;

public class Ava_Move : MonoBehaviour {

	private GameObject target;
	private float speed= 4f;
	private float timer = 1f; 
	float dist;
	// Use this for initialization
	void Start () {
	
		target=GameObject.FindGameObjectWithTag("Player");
	}
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
				GameInstance.instance.damagePlayer (1);
		}
//		if (other.gameObject.name == "DoorBlue") {
//			GameInstance.instance.damagePlayer (1);
//			transform.position = transform.position;
//		}
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance (target.transform.position, transform.position);
		if(dist < 30){
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);

		}
	//	print (1.0 / Time.deltaTime);
	}
}
