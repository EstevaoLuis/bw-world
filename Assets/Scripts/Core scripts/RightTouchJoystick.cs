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
	private bool isActive = true;

	bool greenAvailable = false, blueAvailable = false, redAvailable = false;

	private float activatedTime, lastSpell, spellDelay, lastPowerCheck;

	void Start() {
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
				if(touch.position.x > 560) {
							if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
									fingerCount++;
									if (touch.phase == TouchPhase.Began) {
											print ("Inizio: " + touch.position);
											lastPosition = touch.position;
											transform.position = new Vector3 (lastPosition.x, lastPosition.y, 0f);
									} else {
											//print ("Spostato in: " + touch.position);

											float deltaX = touch.position.x - lastPosition.x;
											float deltaY = touch.position.y - lastPosition.y;
											float distance = Vector2.Distance(touch.position,lastPosition);
											
											if(distance > 20 && (Mathf.Abs(deltaX) > 10 || Mathf.Abs(deltaY) > 10)) {
												string spellColor = "Green";
												
												//Select color
												if(deltaY > 10) {
													if(deltaX < -10) {
														spellColor = "Red";															
													}
													else if(deltaX > 10) {
														spellColor = "Green";
													}
												}
												else if(deltaY < -10) {
													spellColor = "Blue";
												} 

												//Debug.Log (spellColor);
												
												//Select level
												int spellLevel = 0;
												if(distance > 100 && GameInstance.instance.canCastSpell(spellColor,3)) {
													spellLevel = 3;
													spellDelay = 1.5f;
												}
												else if(distance > 60 && GameInstance.instance.canCastSpell(spellColor,2)) {
													spellLevel = 2;
													spellDelay = 0.8f;
												}
												else if(GameInstance.instance.canCastSpell(spellColor,1)) {
													spellLevel = 1;
													spellDelay = 0.3f;
												}	
												
												//Set correct sprites
												if(spellColor == "Green") {
													greenRenderer.sprite = greenSprite[spellLevel+1]; 
													redRenderer.sprite = redSprite[1];
													blueRenderer.sprite = blueSprite[1];
												}
												else if(spellColor == "Blue") {
													greenRenderer.sprite = greenSprite[1]; 
													redRenderer.sprite = redSprite[1];
													blueRenderer.sprite = blueSprite[spellLevel+1];
												}
												else {
													greenRenderer.sprite = greenSprite[1]; 
													redRenderer.sprite = redSprite[spellLevel+1];
													blueRenderer.sprite = blueSprite[1];
												}
												
												//Cast spell
												if(spellLevel > 0 && Time.time > lastSpell + spellDelay) {
													playerController.castSpell(spellColor,spellLevel);
													lastSpell = Time.time;
												}
								
											}
											else {
												greenRenderer.sprite = greenSprite[1]; 
												redRenderer.sprite = redSprite[1];
												blueRenderer.sprite = blueSprite[1];
											}
											if(!greenAvailable) greenRenderer.sprite = greenSprite[0]; 
											if(!blueAvailable) blueRenderer.sprite = blueSprite[0]; 
											if(!redAvailable) redRenderer.sprite = redSprite[0]; 
									}
							}
				
					}
			}

			if(fingerCount == 0) {
				//renderer.color = hidden;
				redRenderer.color = hidden; 
				greenRenderer.color = hidden;
				blueRenderer.color = hidden;
			}
			else {
				//renderer.color = visible;
				redRenderer.color = visible; 
				greenRenderer.color = visible;
				blueRenderer.color = visible;
			}

			//Check for new powers
			if(Time.time > lastPowerCheck + 3f) {
				lastPowerCheck = Time.time;
				int storyLevel = QuestManager.instance.getStoryLevel();
				if(storyLevel>=6) greenAvailable = true;
				else greenAvailable = false;
				if(storyLevel>=18) blueAvailable = true;
				else blueAvailable = false;
				if(storyLevel>=30) redAvailable = true;
				else redAvailable = false;
			}

		}
	}

	public void setActive(bool active) {
		isActive = active;
	}
}
