using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public Texture2D emptyProgressBar; // Set this in inspector.
	public Texture2D fullProgressBar; // Set this in inspector.
	
	private AsyncOperation async = null; // When assigned, load is in progress.

	void Start() {
		loadLevel ("Green World");
	}


	private IEnumerator loadLevel(string levelName) {
		async = Application.LoadLevelAsync(levelName);
		Debug.Log ("Started loading");
		yield return async;
	}
	
	void Update() {
		if (async != null) {
			Debug.Log (async.progress);
			//GUI.DrawTexture(Rect(0, 0, 100, 50), emptyProgressBar);
			//GUI.DrawTexture(Rect(0, 0, 100 * async.progress, 50), fullProgressBar);
		}
	}
}