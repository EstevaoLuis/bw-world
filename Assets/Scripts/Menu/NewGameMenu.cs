using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
		Application.LoadLevel ("Green World");
	}

	public void loadGame() {
		audio.Stop ();
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/playerInfo0.dat", FileMode.Open);
		PlayerData data = (PlayerData) bf.Deserialize(file);
		file.Close();
		//Load scene & set parameters
		Application.LoadLevel (data.scene);
		isLoadedGame = true;

	}

	public void quit() {
		Application.Quit ();
	}

	void Update() {
		if (Input.GetKey (KeyCode.Space)) startGame ();

		if (isLoadedGame) {
			GameObject player = GameObject.FindWithTag ("Player");
			if(player != null) {
				GameInstance.instance.loadData();
				//player.transform.position = new Vector3(gameData["xPosition"].AsFloat,gameData["yPosition"].AsFloat,0);
				//GameObject cameraSystem = GameObject.FindWithTag ("CameraSystem");
				//cameraSystem.transform.position = new Vector3(gameData["xPosition"].AsFloat,gameData["yPosition"].AsFloat,0);
				isLoadedGame = false;
				Destroy (this);
			}
		}
	}

}
