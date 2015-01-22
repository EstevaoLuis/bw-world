using UnityEngine;
using System.Collections;

public class wallwithoutrigid : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	} 
	void OnTriggerEnter(Collider other) {
		other.gameObject.transform.position = new Vector3(67.73f,7.56f,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
