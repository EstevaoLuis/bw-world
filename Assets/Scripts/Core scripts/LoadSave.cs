using UnityEngine;
using System.Collections;

public class LoadSave : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.L)) {
			GameInstance.instance.loadGame();
		}
		else if (Input.GetKey (KeyCode.S)) {
			GameInstance.instance.saveGame();
		}
		else if(Input.GetKey (KeyCode.T)) {
			GameInstance.instance.loadMap("Tutorial",0f,0f);
		}
	}
}
