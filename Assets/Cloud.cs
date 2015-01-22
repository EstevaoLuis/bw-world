using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	private float initialX, initialY;
	private Vector2 target;
	private float area = 5f;
	private float lastDirectionChange;

	// Use this for initialization
	void Start () {
		initialX = transform.position.x;
		initialY = transform.position.y;
		newPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > lastDirectionChange + 8f) {
			newPosition ();
			lastDirectionChange = Time.time;
		}
	}

	private void newPosition() {
		float newX = initialX + Random.Range (-area,area);
		float newY = initialY + Random.Range (-area,area);
		target = new Vector2 (newX,newY);
		rigidbody2D.velocity = new Vector2 (target.x-transform.position.x,target.y-transform.position.y) / 10f ;
		//Debug.Log (rigidbody2D.velocity);
	}
}
