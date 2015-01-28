using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public GameObject door = null;
	public GameObject pressed;
	public bool isBlueSancLever;
	private bool trigger = false;
	public GameObject camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			if(isBlueSancLever == true){
				Instantiate(camera,transform.position,transform.rotation);
				Invoke ("destroyGameObjects",8f);
				trigger = true;
			}
			if(trigger == false){
				Destroy(door);
				Vector2 aux = new Vector2(transform.position.x,transform.position.y);
				Destroy(gameObject);
				Instantiate(pressed, aux, transform.rotation);
			}
			GameInstance.instance.playAudio("Switch2");
		}
	}
	private void destroyGameObjects() {
		Destroy(door);
		Vector2 aux = new Vector2(transform.position.x,transform.position.y);
		Destroy(gameObject);
		Instantiate(pressed, aux, transform.rotation);
		
	}
}
