using UnityEngine;
using System.Collections;

public class ScenesManager : MonoBehaviour {

	public GameObject loadingScene, loadingText, startButton;

	private static ScenesManager _instance;

	public static int currentSlot = 1;
	public static bool restoreSavedGame = false;
	public static bool restoreFromCheckpoint = false;

	private AsyncOperation async;
	private bool waitingToStart = false;
	private float sceneRequested;

	//private GameObject gs, ui;
	private GameObject mainLight, mainCamera, ui;

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
		loadingText.SetActive (false);
		startButton.SetActive (true);

		Debug.Log ("Cambio scena completato");

	}

	public void loadLevel(int level) {
		prepareNewScene ();
		StartCoroutine(asyncLoading (level));
	}

	public void loadLevel(string level) {
		prepareNewScene ();
		StartCoroutine(asyncLoading (level));
	}

	IEnumerator asyncLoading(string level) {
		sceneRequested = Time.time;
		async = Application.LoadLevelAsync (level);
		async.allowSceneActivation = false;
		
		while (!async.isDone) {
			Debug.Log (async.progress);
			if(async.progress >= 0.9f && !waitingToStart && Time.time > sceneRequested + 3f) {
				loadingText.SetActive (false);
				startButton.SetActive (true);
				waitingToStart = true;
			}
			yield return null;
		}
	}

	IEnumerator asyncLoading(int level) {
		sceneRequested = Time.time;
		async = Application.LoadLevelAsync (level);
		async.allowSceneActivation = false;

		while (!async.isDone) {
			Debug.Log (async.progress);
			if(async.progress >= 0.9f && !waitingToStart && Time.time > sceneRequested + 2f) {
				loadingText.SetActive (false);
				startButton.SetActive (true);
				waitingToStart = true;
			}
			yield return null;
		}
	}


	public void startLevel() {
		if (GameInstance.instance != null) GameInstance.instance.destroyInstance ();
		if (UserInterface.instance != null) UserInterface.instance.destroyInstance ();
		startButton.SetActive (false);
		loadingScene.SetActive (false);
		async.allowSceneActivation = true;
		/*
		mainLight.SetActive (true);
		mainCamera.SetActive (true);
		ui.SetActive (true);
		*/
	}

	private void prepareNewScene() {
		loadingScene.SetActive (true);
		loadingText.SetActive (true);
		startButton.SetActive (false);
		waitingToStart = false;
		Time.timeScale = 1f;

		if(GameInstance.instance != null) {
			mainLight = GameObject.FindGameObjectWithTag ("MainLight");
			mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
			ui = GameObject.FindGameObjectWithTag ("UserInterface");
			mainLight.SetActive (false);
			mainCamera.SetActive (false);
			ui.SetActive (false);
		}
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
