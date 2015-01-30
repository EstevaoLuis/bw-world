using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RightTouchJoystick : MonoBehaviour {

	public Image redRenderer,greenRenderer,blueRenderer;

	public Sprite[] redSprite,greenSprite,blueSprite; 

	private PlayerController playerController;

	private Vector4 visible = new Vector4(255,255,255,255);
	private Vector4 hidden = new Vector4(255,255,255,0);

	private Vector2 lastPosition;

	private Image renderer;
	private bool isActive = false;
	private int loadedLevel;

	private bool isLoading = false;
	private float startLoadingTime;

	bool greenAvailable = false, blueAvailable = false, redAvailable = false;

	private bool isRed = false, isBlue = false, isGreen = false;

	private float activatedTime, lastSpell, spellDelay, lastPowerCheck;

	void Start() {
		//isActive = Settings.isMobile;
		renderer = GetComponent<Image> ();
		renderer.color = hidden;
		redRenderer.color = hidden; 
		greenRenderer.color = hidden;
		blueRenderer.color = hidden;
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update() {
		if(isActive) {
			int fingerCount = 0;
			foreach (Touch touch in Input.touches) {
				//Half screen is 480
				if(touch.position.x > 480 && touch.position.y < 450) {
							if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
									fingerCount++;
									if (touch.phase == TouchPhase.Began) {

											print ("Inizio: " + touch.position);
											lastPosition = touch.position;
											if(lastPosition.x < 560) lastPosition.x = 560;
											if(lastPosition.x > 880) lastPosition.x = 880;
											if(lastPosition.y < 80) lastPosition.y = 80;
											transform.position = new Vector3 (lastPosition.x, lastPosition.y, 0f);
											isLoading = true;
											startLoadingTime = Time.time;

									} else if(isLoading) {
											//print ("Spostato in: " + touch.position);

											float deltaX = touch.position.x - lastPosition.x;
											float deltaY = touch.position.y - lastPosition.y;
											float distance = Vector2.Distance(touch.position,lastPosition);
											
											if(distance > 20 && (Mathf.Abs(deltaX) > 10 || Mathf.Abs(deltaY) > 10)) {
												
												//Select color
												if(deltaY > 10) {
													if(deltaX < -10) {
														isRed = true;
													}
													else if(deltaX > 10) {
														isGreen = true;
													}
												}
												else if(deltaY < -10) {
													isBlue = true;
												} 
								
											}
											
											//Select loaded level
											if(Time.time > startLoadingTime + 1.5f) loadedLevel = 3;
											else if(Time.time > startLoadingTime + 0.75f) loadedLevel = 2;
											else loadedLevel = 1;
											
											//Show correct colors
											if(isBlue) blueRenderer.sprite = blueSprite[1 + GameInstance.instance.maxSpellLevel("blue",loadedLevel)];
											else blueRenderer.sprite = blueSprite[1];
											if(isRed) redRenderer.sprite = redSprite[1 + GameInstance.instance.maxSpellLevel("red",loadedLevel)];
											else redRenderer.sprite = redSprite[1];
											if(isGreen) greenRenderer.sprite = greenSprite[1 + GameInstance.instance.maxSpellLevel("green",loadedLevel)];
											else greenRenderer.sprite = greenSprite[1];
									}
							}
							//Cast spell
							else if(isLoading) {
								string spellName = GameInstance.instance.selectAvailableSpell (isRed && redAvailable, isGreen && greenAvailable, isBlue && blueAvailable, loadedLevel);
								bool status = GameInstance.instance.playerCastSpell (spellName);
								isLoading = false;
								resetColors();
							}
							
							//reset if not availables
							if(!greenAvailable) greenRenderer.sprite = greenSprite[0];
							if(!blueAvailable) blueRenderer.sprite = blueSprite[0];
							if(!redAvailable) redRenderer.sprite = redSprite[0];

					}
			}

			if(fingerCount == 0) {
				hide ();
			}
			else {
				show ();
			}

			//Check for new powers
			if(Time.time > lastPowerCheck + 3f) {
				lastPowerCheck = Time.time;
				int storyLevel = QuestManager.instance.getStoryLevel();
				if(storyLevel>=Settings.greenStoryLevel) greenAvailable = true;
				else greenAvailable = false;
				if(storyLevel>=Settings.blueStoryLevel) blueAvailable = true;
				else blueAvailable = false;
				if(storyLevel>=Settings.redStoryLevel) redAvailable = true;
				else redAvailable = false;

			}

		}
	}

	private void show() {
		redRenderer.color = visible; 
		greenRenderer.color = visible;
		blueRenderer.color = visible;
	}

	private void hide() {
		redRenderer.color = hidden; 
		greenRenderer.color = hidden;
		blueRenderer.color = hidden;
	}

	private void resetColors() {
		isBlue = false;
		isRed = false;
		isGreen = false;
		blueRenderer.sprite = blueSprite[1];
		redRenderer.sprite = redSprite[1];
		greenRenderer.sprite = greenSprite[1];
	}

	public void setActive(bool active) {
		isActive = active;
	}
}
