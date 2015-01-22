using UnityEngine;
using System.Collections;

public class Cyan : MonoBehaviour {

	private GameObject crystal;
	private GameObject aux_1;
	private GameObject aux_2;
	private Spell sp_cyan;

	// Use this for initialization
	void Start () {
	
		crystal = GameObject.Find ("Crystal");
		//two = GameObject.Find("Crystal");

	}
	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.tag == "Player") {

			aux_1=(GameObject)Instantiate(crystal,new Vector3(115.7191f,52.59612f,0),transform.rotation);
			aux_2 = (GameObject)Instantiate(crystal,new Vector3(110.0972f,53.51508f,0),transform.rotation);


		}

		if (other.gameObject.tag == "Spell") {
			sp_cyan = other.gameObject.GetComponent<Spell>();
			if(sp_cyan.color ==  "cyan"){
			Destroy(aux_1);
			Destroy(aux_2);
			}
			
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
