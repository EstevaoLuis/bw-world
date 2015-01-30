using UnityEngine;
using System.Collections;

public class TriggerActivator : MonoBehaviour {

	public GameObject[] objectsToActivate;
	public GameObject[] objectsToDeactivate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			foreach (GameObject objectToActivate in objectsToActivate)
					objectToActivate.SetActive (true);
			foreach (GameObject objectToDeactivate in objectsToDeactivate)
					objectToDeactivate.SetActive (false);
			gameObject.SetActive(false);
		}
	}

}
