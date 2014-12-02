using UnityEngine;
using System.Collections;

public class Melee_Enemy : MonoBehaviour {

	public int damage;
	private GameObject target;
	private int counter = 0;
	public int duration_of_attack = 10;
	// Use this for initialization
	void Start () {
	
		target = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
		if (counter == duration_of_attack) {
			Destroy(gameObject);
			counter = 0;		
		}
		rigidbody2D.velocity = new Vector3 (target.transform.position.x, target.transform.position.y, 0);
		counter ++;

	}
}
