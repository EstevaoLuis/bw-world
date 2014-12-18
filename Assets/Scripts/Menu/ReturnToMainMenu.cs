using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space))
						backToMainMenu ();
	}

	public void backToMainMenu() {
		Application.LoadLevel ("Main Menu");
	}
}
