using UnityEngine;
using System.Collections;

public class SpellSwitch : MonoBehaviour {
	public string Colour; // green, blue, red, all
	public bool activated = false;
	public GameObject[] gameObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (activated == false){
			if (other.gameObject.tag == "Spell") {
				Spell spellParameters = (Spell)other.gameObject.GetComponent ("Spell");
				string color = spellParameters.color;

				if ((Colour == "all") || (color == Colour)){
					activated = true;
					// TODO animation
					foreach(GameObject gameObject in gameObjects)
						Destroy(gameObject); // Maybe add more events
				}
			}
		}
	}
}
