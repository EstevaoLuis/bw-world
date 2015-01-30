using UnityEngine;
using System.Collections;

public class GetNewSpellColor : MonoBehaviour {

	private CircleCollider2D collider;
	private PlayerController controller;
	private bool isActivated = false;
	public bool isGreen = true;
	public bool isRed = false;

	// Use this for initialization
	void Start () {
		collider = GetComponent<CircleCollider2D> ();
		controller = GameInstance.instance.getPlayerController ();
	}


	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player" && !isActivated) {
			isActivated = true;
			Vector3 newPosition = other.gameObject.transform.position;
			controller.isAvailable(false);
			if(isGreen == true){
				GameInstance.instance.playAnimation("NewSpellGreen",new Vector3 (newPosition.x,newPosition.y,1f));
			}else if (!isRed){
				GameInstance.instance.playAnimation("NewSpellBlue",new Vector3 (newPosition.x,newPosition.y,1f));
			}else{
				GameInstance.instance.playAnimation("NewSpellRed",new Vector3 (newPosition.x,newPosition.y,1f));
			}
			GameInstance.instance.playAudio("Up3");
			Invoke ("showMessage",3f);
		}
	}

	public void showMessage() {
		controller.isAvailable (true);
	}

}
