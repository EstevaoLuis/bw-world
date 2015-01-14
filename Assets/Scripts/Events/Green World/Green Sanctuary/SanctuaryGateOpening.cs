using UnityEngine;
using System.Collections;

public class SanctuaryGateOpening : MonoBehaviour {

	public GateController gate;

	private bool isActivated = false;
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player" && !isActivated) {
			isActivated = true;
			GameInstance.instance.playAnimation("Rune", transform.position);
			GameInstance.instance.playAudio("Magic3");
			renderer.color = new Vector4(255f,255f,255f,0f);
			Debug.Log ("Opening gate...");
			Invoke("openGate",2f);
		}
	}

	void openGate() {
		Debug.Log ("Gate open!!");
		gate.openGate();
		Destroy(gameObject);
	}
}
