using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ReturnToMainMenu : MonoBehaviour {

	private bool isRestarted = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (isRestarted && GameInstance.instance != null) {
			GameInstance.instance.continueFromCheckpoint();
			Destroy (gameObject);
		}
	}

	public void backToMainMenu() {
		Application.LoadLevel ("Main Menu");
	}

	public void tryAgain() {
		if (File.Exists (Application.persistentDataPath + "/checkpoint.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/checkpoint.dat", FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();
			Application.LoadLevel (data.scene);
			isRestarted = true;
		}
	}
}
