using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ReturnToMainMenu : MonoBehaviour {
	

	public void backToMainMenu() {
		Application.LoadLevel ("Main Menu");
	}

	public void tryAgain() {
		if (File.Exists (Application.persistentDataPath + "/checkpoint.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/checkpoint.dat", FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();
			ScenesManager.restoreFromCheckpoint = true;
			ScenesManager.restoreSavedGame = false;
			Application.LoadLevel (data.scene);
		}
	}
}
