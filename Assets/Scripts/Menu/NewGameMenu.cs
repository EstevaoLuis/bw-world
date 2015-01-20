using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class NewGameMenu : MonoBehaviour {

	public GameObject defaultPanel, loadPanel, mainCanvas;
	public Text slot1,slot2,slot3;
	
	private JSONNode gameData;

	private AsyncOperation async;

	// Use this for initialization
	void Start () {
		loadPanel.SetActive (false);
		audio.Play ();
		updateSlotDescriptions ();
	}

	public void updateSlotDescriptions() {
		if (File.Exists (Application.persistentDataPath + "/playerInfo1.dat")) {
			slot1.text = loadSlotData(1);
		}
		else slot1.text = "EMPTY";
		
		if (File.Exists (Application.persistentDataPath + "/playerInfo2.dat")) {
			slot2.text = loadSlotData(2);
		}
		else slot2.text = "EMPTY";
		
		if (File.Exists (Application.persistentDataPath + "/playerInfo3.dat")) {
			slot3.text = loadSlotData(3);
		}
		else slot3.text = "EMPTY";
	}

	private string loadSlotData(int slot) {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/playerInfo" + slot + ".dat", FileMode.Open);
		PlayerData data = (PlayerData) bf.Deserialize(file);
		file.Close();
		return "LV " + data.level + " - " + data.sceneName;
	}

	public void startGame() {
		audio.Stop ();
		ScenesManager.currentSlot = 1;
		ScenesManager.restoreSavedGame = false;
		ScenesManager.restoreFromCheckpoint = false;
		ScenesManager.instance.loadLevel (2);
		mainCanvas.SetActive(false);
	}

	public void back() {
		loadPanel.SetActive (false);
		defaultPanel.SetActive (true);
	}

	public void loadGame() {
		loadPanel.SetActive (true);
		defaultPanel.SetActive (false);
	}

	public void loadSlot(int slot) {
		//audio.Stop ();
		BinaryFormatter bf = new BinaryFormatter();
		if(File.Exists(Application.persistentDataPath + "/playerInfo" + slot + ".dat")) {
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo" + slot + ".dat", FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();
			ScenesManager.currentSlot = slot;
			ScenesManager.restoreSavedGame = true;
			ScenesManager.restoreFromCheckpoint = false;
			ScenesManager.instance.loadLevel(data.scene);
			mainCanvas.SetActive(false);
		}
	}

	/*
	IEnumerator loadAsync() {
		async = Application.LoadLevelAsync("Green World");
		yield return async;
		Debug.Log("Loading complete");
	}
	*/

	public void quit() {
		Application.Quit ();
	}
	/*
	void Update() {
		if (isLoadedGame) {
			//Debug.Log(async.progress);
			GameObject player = GameObject.FindWithTag ("Player");
			if(player != null) {
				GameInstance.instance.loadData();
				//player.transform.position = new Vector3(gameData["xPosition"].AsFloat,gameData["yPosition"].AsFloat,0);
				//GameObject cameraSystem = GameObject.FindWithTag ("CameraSystem");
				//cameraSystem.transform.position = new Vector3(gameData["xPosition"].AsFloat,gameData["yPosition"].AsFloat,0);
				isLoadedGame = false;
				Destroy (gameObject);
			}
		}
	}
	*/

}
