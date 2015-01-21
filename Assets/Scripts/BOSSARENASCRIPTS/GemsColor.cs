using UnityEngine;
using System.Collections;

public class GemsColor : MonoBehaviour {

	// Use this for initialization
	private GameObject [] gems;
	private int numb_of_gems = 4;

	void Start () {
	
		gems = new GameObject[numb_of_gems]; 

	}

	bool triggered(){
		return false;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
