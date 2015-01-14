using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Resume(){
		//Time.timeScale = 1;
		GameInstance.instance.pauseGame ();
		Destroy (pauseMenu);
	}

	public void Save(){}

	public void Load(){}

	public void Exit(){}
}
