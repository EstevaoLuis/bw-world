﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveController1 : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject saveMenu;
	public static int mode; // 0 save; 1 load

	public Text slot1,slot2,slot3;

	// Use this for initialization
	void Start () {
		Debug.Log ("Save Path: " + Application.persistentDataPath);
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

	public void Save(int slot){
		saveMenu.SetActive (false);
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		PauseMenu.status = false;
		if (mode == 0) {  // save
			Debug.Log ("Save Slot-> " + slot);
			ScenesManager.currentSlot = slot;
			GameInstance.instance.saveGame();
			GameInstance.instance.playAudio ("Save");
		} else { //load
			Debug.Log ("Load Slot-> " + slot);
			ScenesManager.currentSlot = slot;
			ScenesManager.restoreSavedGame = true;
			ScenesManager.restoreFromCheckpoint = false;
			if(File.Exists(Application.persistentDataPath + "/playerInfo" + slot + ".dat")) {
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(Application.persistentDataPath + "/playerInfo" + slot + ".dat", FileMode.Open);
				PlayerData data = (PlayerData) bf.Deserialize(file);
				file.Close();
				ScenesManager.instance.loadLevel(data.sceneName);
			}
			GameInstance.instance.playAudio ("Load");
		}
		updateSlotDescriptions ();
	}

	public void Resume(){
		saveMenu.SetActive (false);
		pauseMenu.SetActive (true);
		GameInstance.instance.playAudio ("Cancel1");
	}
}


