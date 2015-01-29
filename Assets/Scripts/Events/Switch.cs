using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public GameObject door = null;
	public GameObject pressed;
	public float time;
	public bool NeedsScene;
	private bool trigger = false;
	public GameObject camera;
	private Vector3 save_position;
	// Use this for initialization
	void Start () {
		save_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			if(NeedsScene == true){
				//save_position = other.transform.position;
				Instantiate(camera,transform.position,transform.rotation);
				Invoke ("destroyGameObjects",time);
				//other.transform.position = save_position;
				trigger = true;
				other.gameObject.transform.position = save_position;
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
