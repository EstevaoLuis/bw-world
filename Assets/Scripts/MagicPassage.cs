using UnityEngine;
using System.Collections;

public class MagicPassage : MonoBehaviour {

	public string level_name;
	public Vector3 newCoordinates = new Vector3(0f,50f,0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			if(ScenesManager.instance != null) {


				ScenesManager.restoreSavedGame = false;
				ScenesManager.restoreFromCheckpoint = false;
				ScenesManager.instance.loadLevel(level_name);
				ScenesManager.restoreCoordinates = true;
				ScenesManager.newCoordinates = newCoordinates;

			}
			else {
				Application.LoadLevel(level_name);
				GameInstance.instance.moveGameSystem(newCoordinates);
			}
		}
	}
}