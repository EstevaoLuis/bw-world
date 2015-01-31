using UnityEngine;
using System.Collections;

public class Cyan : MonoBehaviour {

	private GameObject crystal;
	private GameObject aux_1;
	private GameObject aux_2;
	private Spell sp_cyan;
	private GameObject spell;

	private bool isActivated = false;

	// Use this for initialization
	void Start () {
	
		crystal = GameObject.Find ("Crystal");

		//two = GameObject.Find("Crystal");

	}
	void OnCollisionEnter2D (Collision2D other){

		if (!isActivated && other.gameObject.tag == "Player") {
			isActivated = true;
			GameInstance.instance.playAudio ("Magic3");
			aux_1=(GameObject)Instantiate(crystal,new Vector3(113f,49.6f,0),transform.rotation);
			aux_2 = (GameObject)Instantiate(crystal,new Vector3(110.0972f,53.51508f,0),transform.rotation);

		}

		else if (other.gameObject.tag == "Spell") {
			Spell spell = other.gameObject.GetComponent<Spell>();
			if(spell.color == "cyan") {
				Invoke ("destroyCrystals", 0.5f);
			}
		}

	}

	private void destroyCrystals () {
		GameInstance.instance.playAudio ("Magic1");
		Destroy (aux_1);
		Destroy (aux_2);
		Destroy(gameObject);
	}
}
