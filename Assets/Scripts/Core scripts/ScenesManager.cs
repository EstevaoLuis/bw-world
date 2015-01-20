using UnityEngine;
using System.Collections;

public class ScenesManager : MonoBehaviour {

	public GameObject loadingScene;

	private static ScenesManager _instance;

	public static int currentSlot = 1;
	public static bool restoreSavedGame = false;
	public static bool restoreFromCheckpoint = false;

	//Instance management
	public static ScenesManager instance
	{
		get
		{
			return _instance;
		}
	}
	
	void OnLevelWasLoaded(int level) {
		Time.timeScale = 1.0f;
		loadingScene.SetActive (false);
		Debug.Log ("Caricamento completato");
	}

	public void loadLevel(int level) {
		prepareNewScene ();
		Application.LoadLevel (level);
	}

	public void loadLevel(string level) {
		prepareNewScene ();
		Application.LoadLevel (level);
	}

	private void prepareNewScene() {
		loadingScene.SetActive (true);
		if (GameInstance.instance != null) GameInstance.instance.destroyInstance ();
		if (UserInterface.instance != null) UserInterface.instance.destroyInstance ();
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(gameObject);
		}
	}

}
