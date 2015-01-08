using UnityEngine;
using System.Collections;

public class minimap : MonoBehaviour {

	private GameObject target;
	// Use this for initialization
	void Start () {
	
		target = GameObject.FindGameObjectWithTag("Player");
		transform.position = new Vector3 (target.transform.position.x , target.transform.position.y, -5); 
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3 (target.transform.position.x , target.transform.position.y, -5); 
		//transform.LookAt (target.transform);


	}
}
