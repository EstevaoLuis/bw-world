using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject menuP;
	public GameObject saveP;
	public static bool status = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			pauseSwitch ();
		}
	}

	public void pauseSwitch(){
		Time.timeScale = 1 - Time.timeScale;
		status = !status;
		menuP.SetActive(status);
		if (!status)
			saveP.SetActive (false);
	}

	public void Resume(){
		pauseSwitch ();
		Debug.Log ("Game Resumed");
	}

	public void Save(){
		// open Save Menu
		SaveController1.mode = 0;
		menuP.SetActive (false);
		saveP.SetActive (true);
	}

	public void Load(){
		// open Load Menu
		SaveController1.mode = 1;
		menuP.SetActive (false);
		saveP.SetActive (true);
	}

	public void Exit(){
		Application.Quit ();
	}
	
}
