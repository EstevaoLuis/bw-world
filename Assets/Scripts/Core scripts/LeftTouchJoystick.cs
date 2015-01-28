using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeftTouchJoystick : MonoBehaviour {
	
	public Sprite defaultSprite;
	public Sprite rightSprite;
	public Sprite leftSprite;
	public Sprite upSprite;
	public Sprite downSprite;
	public PlayerController playerController;

	private bool isActive;

	private Vector4 visible = new Vector4(255,255,255,255);
	private Vector4 hidden = new Vector4(255,255,255,0);

	private Vector2 lastPosition;

	private Image renderer;

	void Start() {
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		renderer = GetComponent<Image> ();
		isActive = Settings.isMobile;
		if(!isActive) renderer.color = hidden;
	}

	void Update() {
		if(isActive) {
			int fingerCount = 0;
			foreach (Touch touch in Input.touches) {
				//Half screen is 480
				if(touch.position.x < 480) {
							if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
									fingerCount++;
									if (touch.phase == TouchPhase.Began) {
											print ("Inizio: " + touch.position);
											lastPosition = touch.position;
											if(lastPosition.x > 400) lastPosition.x = 400;
											if(lastPosition.x < 80) lastPosition.x = 80;
											transform.position = new Vector3 (lastPosition.x, lastPosition.y, 0f);
											renderer.sprite = defaultSprite;
									} else {
											print ("Spostato in: " + touch.position);
											float deltaX = touch.position.x - lastPosition.x;
											float deltaY = touch.position.y - lastPosition.y;
											if (Mathf.Abs (deltaY) > Mathf.Abs (deltaX)) {
													if (deltaY > 0) {
															renderer.sprite = upSprite;
															playerController.moveUp ();
													} else {
															renderer.sprite = downSprite;
															playerController.moveDown ();
													}
											} else if (deltaX != 0) {
													if (deltaX > 0) {
															renderer.sprite = rightSprite;
															playerController.moveRight ();
													} else {
															renderer.sprite = leftSprite;
															playerController.moveLeft ();
													}
											} 
											else {
													renderer.sprite = defaultSprite;
													playerController.stopMovement();
											}
											
									}

							}
				
					}
			}

			if(fingerCount == 0) {
				renderer.color = hidden;
				renderer.sprite = defaultSprite;
				playerController.stopMovement();
			}
			else renderer.color = visible;
		}
	}
}
