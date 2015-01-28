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
		GameInstance.instance.playAudio ("Cancel2");
		Time.timeScale = 1 - Time.timeScale;
		status = !status;
		menuP.SetActive(status);
		if (!status)
			saveP.SetActive (false);
	}

	public void Resume(){
		pauseSwitch ();
		Debug.Log ("Game Resumed");
		GameInstance.instance.playAudio ("Cancel2");
	}

	public void Save(){
		// open Save Menu
		SaveController1.mode = 0;
		menuP.SetActive (false);
		saveP.SetActive (true);
		GameInstance.instance.playAudio ("Save");
	}

	public void Load(){
		// open Load Menu
		SaveController1.mode = 1;
		menuP.SetActive (false);
		saveP.SetActive (true);
		GameInstance.instance.playAudio ("Load");
	}

	public void Exit(){
		Application.Quit ();
		GameInstance.instance.playAudio ("Cancel1");
	}
	
}
