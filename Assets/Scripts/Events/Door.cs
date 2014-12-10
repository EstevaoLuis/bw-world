using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private GameObject lever_1;
	private GameObject lever_2;

	private Lever lv_1;
	private Lever lv_2;

//	private GameObject lever_1;
//	private GameObject lever_2;
//	int status_1;
//	int status_2;
	// Use this for initialization
	void Awake () {

		lever_1 = GameObject.Find ("lever_1");
		lv_1 =  lever_1.GetComponent<Lever> ();
		//lever_1 = GameObject.FindGameObjectWithTag ("lever");
		lever_2 = GameObject.Find("lever_2");
		lv_2 = lever_2.GetComponent<Lever> ();
		//lever_2 = GameObject.FindGameObjectWithTag ("lever");
	
	}

	void Start(){

	}
	

	void unlock(){

		if (lv_1.status_lever == 1 && lv_2.status_lever == 1) {
			Destroy(gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		unlock ();
	}
}
