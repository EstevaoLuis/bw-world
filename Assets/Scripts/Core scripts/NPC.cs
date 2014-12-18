using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	GameObject textObject;

	// Use this for initialization
	void Start () {
		Collider collider = GetComponent<Collider> () as Collider;
		Vector3 textPosition = new Vector3 (transform.position.x, transform.position.y + collider.bounds.size.y, -1);
		textObject = GameInstance.instance.showNPCText ("Ciao!!", textPosition);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
