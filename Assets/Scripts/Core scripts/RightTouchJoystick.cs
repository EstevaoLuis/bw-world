using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RightTouchJoystick : MonoBehaviour {

	private PlayerController playerController;

	private Vector4 visible = new Vector4(255,255,255,255);
	private Vector4 hidden = new Vector4(255,255,255,0);

	private Vector2 lastPosition;

	private Image renderer;
	private bool isActive = true;

	void Start() {
		renderer = GetComponent<Image> ();
		renderer.color = hidden;
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update() {
		if(isActive) {
			int fingerCount = 0;
			foreach (Touch touch in Input.touches) {
				//Half screen is 480
				if(touch.position.x > 560) {
							if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
									fingerCount++;
									if (touch.phase == TouchPhase.Began) {
											print ("Inizio: " + touch.position);
											lastPosition = touch.position;
											transform.position = new Vector3 (lastPosition.x, lastPosition.y, 0f);
									} else {
											print ("Spostato in: " + touch.position);
											float deltaX = touch.position.x - lastPosition.x;
											float deltaY = touch.position.y - lastPosition.y;
											if(deltaY > 10) {
												playerController.redSpell();
											}
											else if(deltaY < -10) {
												if(deltaX < -10) {
													playerController.greenSpell();
												}
												else if(deltaX > 10) {
													playerController.blueSpell();
												}
											}
									}

							}
				
					}
			}

			if(fingerCount == 0) {
				renderer.color = hidden;
			}
			else renderer.color = visible;
		}
	}

	public void setActive(bool active) {
		isActive = active;
	}
}
