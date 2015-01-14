using UnityEngine;
using System.Collections;
using SimpleJSON;

public class NewGameMenu : MonoBehaviour {

	private bool isLoadedGame = false;
	private JSONNode gameData;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		audio.Play ();
	}


	public void startGame() {
		audio.Stop ();
		Application.LoadLevel (1);
	}

	public void loadGame() {
		audio.Stop ();
		string gameJsonText = System.IO.File.ReadAllText ("Assets/Resources/GameData.json");
		gameData = JSONNode.Parse (gameJsonText);
		//Load scene & set parameters
		Application.LoadLevel (gameData ["scene"].AsInt);
		isLoadedGame = true;

	}

	void Update() {
		if (Input.GetKey (KeyCode.Space)) startGame ();

		if (isLoadedGame) {
			GameObject player = GameObject.FindWithTag ("Player");
			if(player != null) {
				player.transform.position = new Vector3(gameData["xPosition"].AsFloat,gameData["yPosition"].AsFloat,0);
				GameObject cameraSystem = GameObject.FindWithTag ("CameraSystem");
				cameraSystem.transform.position = new Vector3(gameData["xPosition"].AsFloat,gameData["yPosition"].AsFloat,0);
				isLoadedGame = false;
				Destroy (this);
			}
		}
	}

}
