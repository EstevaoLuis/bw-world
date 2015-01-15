using UnityEngine;
using System.Collections;

public class SaveController1 : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject saveMenu;

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
		Debug.Log ("Slot-> " + slot);
		// TODO Real implementation
		Resume ();
	}

	public void Resume(){
		saveMenu.SetActive (false);
		pauseMenu.SetActive (true);
	}
}
