using UnityEngine;
using System.Collections;

public class LockKey : MonoBehaviour {

	public int totalKeys = 1;
	private int keysFound = 0;
	
	public GameObject door;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			if (totalKeys == keysFound){
				Destroy (door);
				Destroy (gameObject);
			}
		}
	}
	
	public void KeyFound(){
		keysFound++;
	}

	public int GetKeyFound(){
		return keysFound;
	}
	
}

