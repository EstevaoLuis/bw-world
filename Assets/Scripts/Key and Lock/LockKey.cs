using UnityEngine;
using System.Collections;

public class LockKey : MonoBehaviour {

	public int totalKeys = 1;
	private int keysFound = 0;

	private FadeObjectInOut fadingText;
	
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
			else{
				var newPosition = transform.position + new Vector3(-1.9f, 1.9f);
				var text = (totalKeys-keysFound).ToString() + " Remaining keys";
				var textObject = GameInstance.instance.showNPCText (text,newPosition);
				fadingText = textObject.GetComponent("FadeObjectInOut") as FadeObjectInOut;
				fadingText.FadeIn(1);
			}
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			if (totalKeys != keysFound && fadingText != null){
				fadingText.FadeOut(1);
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

