using UnityEngine;
using System.Collections;

public class StrongWall : MonoBehaviour {

	// Use this for initialization
	private BoxCollider2D col;
	private GameObject wall;

	void Start () {
	
		wall = GameObject.FindGameObjectWithTag ("Wall");
		col = gameObject.GetComponent<BoxCollider2D> ();

	}


	
	// Update is called once per frame
	void Update () {
	
		col.isTrigger = false;

	}
}
