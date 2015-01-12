using UnityEngine;
using System.Collections;

public class GateController : MonoBehaviour {

	BoxCollider2D collider;
	SpriteRenderer renderer;

	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		renderer = GetComponent<SpriteRenderer> ();
	}
	
	public void openGate() {
		collider.isTrigger = true;
		renderer.color = new Vector4 (255f,255f,255f,0f);
	}
	
	public void closeGate() {
		collider.isTrigger = false;
		renderer.color = new Vector4 (255f,255f,255f,255f);
	}
}
