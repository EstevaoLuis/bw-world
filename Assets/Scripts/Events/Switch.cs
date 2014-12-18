using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public GameObject door = null;
	public GameObject pressed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			Destroy(door);
			Vector2 aux = new Vector2(transform.position.x,transform.position.y);
			Destroy(gameObject);
			Instantiate(pressed, aux, transform.rotation);
			// TODO Animation switch pressed
		}
	}
}
