using UnityEngine;
using System.Collections;

public class SaveController1 : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject saveMenu;
	public static int mode; // 0 save; 1 load

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.K)) {
			Resume();
		}
	}

	public void Save(int slot){
		if (mode == 0) {  // save
			Debug.Log ("Save Slot-> " + slot);
			GameInstance.instance.setCurrentSlot(slot);
			GameInstance.instance.saveGame();
		} else { //load
			Debug.Log ("Load Slot-> " + slot);
			GameInstance.instance.setCurrentSlot(slot);
			GameInstance.instance.loadGame();
		}
		Resume ();
	}

	public void Resume(){
		saveMenu.SetActive (false);
		pauseMenu.SetActive (true);
	}
}


