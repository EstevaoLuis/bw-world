using UnityEngine;
using System.Collections;

public class Avalanche : MonoBehaviour {

	private GameObject target;
	private float speed;
	public GameObject snow_ball;

	// Use this for initialization

	void Start () {
	
	}
	void StartStorm (){
		snow_ball = (GameObject) Instantiate (snow_ball, transform.position, transform.rotation);
	}
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			StartStorm();
//			Destroy(gameObject);
		}
				
	}

	
	// Update is called once per frame
	void Update () {
		//snow_ball.transform.position = Vector3.MoveTowards (transform.position, target.transform);

	}
}
