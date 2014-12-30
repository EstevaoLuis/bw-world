using UnityEngine;
using System.Collections;

public class LoadSave : MonoBehaviour {

	private bool isNewScene = false;
	private GameObject gameSystem;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.L)) {
			load ();
		}
		else if (Input.GetKey (KeyCode.X)) {
			save ();

		}
		else if(Input.GetKey (KeyCode.T)) {
			GameInstance.instance.loadMap("Tutorial",0f,0f);
		}

		if (isNewScene) {
			gameSystem = GameObject.FindWithTag("GameSystem");
			if(gameSystem!= null) {
				Destroy (gameSystem.gameObject);
				isNewScene = false;
			}
		}

	}

	public void load() {
		GameInstance.instance.loadGame();
		Debug.Log ("GS: " + GameObject.FindWithTag("GameSystemActive"));
		isNewScene = true;
	}

	public void save() {
		GameInstance.instance.saveGame();
	}

}
