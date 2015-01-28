using UnityEngine;
using System.Collections;

public class Ava_Move : MonoBehaviour {

	private GameObject target;
	private GameObject Spell;
	public float speed;
	private float timer = 1f; 
	float dist;
	int avoidcatch;
	// Use this for initialization
	void Start () {
	
		target=GameObject.FindGameObjectWithTag("Player");

	}
	void OnCollisionEnter2D (Collision2D other){

//		if (Spell != null) {
//
//			Physics2D.IgnoreCollision (this.collider2D, Spell.collider2D);
//		}

		if (other.gameObject.tag == "Player") {
						
			GameInstance.instance.damagePlayer (10);
			GameInstance.instance.playAnimation("Hit",target.transform.position);
						
			}
			transform.Translate( Vector3.forward*Time.deltaTime); 
				
	}
	
	
	
	
	// Update is called once per frame
	void Update () {

//		Spell = GameObject.FindGameObjectWithTag("Spell");

		dist = Vector3.Distance (target.transform.position, transform.position);
		if(dist < 30){
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
			transform.position = new Vector3(transform.position.x,transform.position.y,-1);
//		if(Vector3.Distance(transform.position,target.transform.position) < avoidcatch){
//				transform.position = transform.position - new Vector3(4,4,0);
//			}
		}
	//	print (1.0 / Time.deltaTime);
	}
}
