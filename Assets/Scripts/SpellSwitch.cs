using UnityEngine;
using System.Collections;

public class SpellSwitch : MonoBehaviour {
	public string Colour; // green, blue, red, all
	public bool activated = false;
	public GameObject[] gameObjects;
	public GameObject camera;
	private GameObject player;
	//float timer = 5f;


	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Camera_to_door(){

		if (activated == true) {
			Instantiate(camera, player.transform.position,transform.rotation);
			//camera.collider2D.enabled=true;
		}

	}

	void OnCollisionEnter2D(Collision2D other){
		if (activated == false){
			if (other.gameObject.tag == "Spell") {
				Spell spellParameters = (Spell)other.gameObject.GetComponent ("Spell");
				string color = spellParameters.color;

				if ((Colour == "all") || (color == Colour)){
		
					activated = true;
					// TODO animation
			

				}
				Camera_to_door();
				Invoke ("destroyGameObjects",2f);
			}
		}
	}

	private void destroyGameObjects() {
		foreach(GameObject gameObject in gameObjects)
			Destroy(gameObject); // Maybe add more events

	}
}
