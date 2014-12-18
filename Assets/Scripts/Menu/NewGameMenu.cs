using UnityEngine;
using System.Collections;

public class NewGameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) startGame ();
	}

	public void startGame() {
		Application.LoadLevel ("Level01");
	}
}
