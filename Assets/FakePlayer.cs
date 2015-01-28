using UnityEngine;
using System.Collections;
using SimpleJSON;

public class FakePlayer : MonoBehaviour {

	public float speed = 5f;
	private bool useJoystick = false;

	private float lastMovement, lastSpell;
	private Vector2 direction;
	private Animator animator;

	private JSONNode spells;

	// Use this for initialization
	void Start () {
		useJoystick = Settings.isMobile;
		animator = GetComponent<Animator> ();
		TextAsset spellsJson = Resources.Load("SpellsDatabase") as TextAsset;
		spells = JSONNode.Parse(spellsJson.text);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!useJoystick) {
						//Movement
						if (Input.GetKey (KeyCode.DownArrow)) {
								moveDown ();
						} else if (Input.GetKey (KeyCode.UpArrow)) {
								moveUp ();
						} else if (Input.GetKey (KeyCode.LeftArrow)) {
								moveLeft ();
						} else if (Input.GetKey (KeyCode.RightArrow)) {
								moveRight ();
						} else {
								stopMovement ();
						}
						//Spells
						if (Time.time > lastSpell + 0.05f) {
								if (Input.GetKey (KeyCode.W)) {
										castSpell ("Red 1");
								} else if (Input.GetKey (KeyCode.A)) {
										castSpell ("Blue 1");
								} else if (Input.GetKey (KeyCode.D)) {
										castSpell ("Green 1");
								}
						}
				}
	}

	public void moveDown() {
			animator.Play ("WalkDown");
			direction = new Vector2 (0.0f, -1.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
	}
	public void moveUp() {
			animator.Play ("WalkUp");
			direction = new Vector2 (0.0f, 1.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
	}
	public void moveLeft() {
			animator.Play ("WalkLeft");
			direction = new Vector2 (-1.0f, 0.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
	}
	public void moveRight() {
			animator.Play ("WalkRight");
			direction = new Vector2 (1.0f, 0.0f);
			//Vector2 newVelocity = direction * speed;
			//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
			rigidbody2D.velocity = direction * speed;
			lastMovement = Time.time;
	}
	public void stopMovement() {
		Vector2 newVelocity = new Vector2 (0, 0);
		//rigidbody2D.velocity = new Vector2 ((rigidbody2D.velocity.x + newVelocity.x) / 2, (rigidbody2D.velocity.y + newVelocity.y) / 2);
		rigidbody2D.velocity = newVelocity;
		lastMovement = Time.time;
	}

	public void castSpell(string color, int level) {
		castSpell (color + " " + level);
	}

	public void castSpell(string spellName) {
		string spellTag = "Spell";
		int bonusDamage = 0;
		float distance = 2f;
		float minSpeed = 0f;

		//Check if spell is available
		if (spellName == null) return;
		JSONNode spellData = spells[spellName];
		if (spellData == null) return;
		
		//Instances an energy sphere
		GameObject spellPrefab = Resources.Load("Spells/" + spellData["color"] + "Spell") as GameObject;
		Vector3 newPosition = transform.position + (new Vector3(direction.x * distance, direction.y * distance, -0.3f));
		if(spellTag == "SpellEnemy") {
			float randomPositionModification = 0f;
			if(direction.x == 0f) newPosition.x += UnityEngine.Random.Range(-1f, 1f) * distance / 2;
			else newPosition.y += UnityEngine.Random.Range(-1f, 1f) * distance / 2;
		}
		GameObject energySphere = (GameObject) Instantiate(spellPrefab, newPosition, new Quaternion(0,0,0,1));
		energySphere.tag = spellTag; 
		energySphere.transform.localScale = new Vector3 (spellData["scale"].AsFloat,spellData["scale"].AsFloat,1f);
		
		//Set spell parameters
		Spell spellParameters = (Spell) energySphere.GetComponent("Spell");
		spellParameters.damage = spellData["damage"].AsInt + bonusDamage;
		
		spellParameters.duration = spellData["duration"].AsFloat;
		spellParameters.color = spellData["color"];
		spellParameters.area = spellData["area"].AsFloat;
		spellParameters.rigidbody2D.mass = spellData["mass"].AsInt;
		
		//Set animation
		GameObject spellAnimation = Resources.Load("Spells/Animations/" + spellName) as GameObject;
		spellParameters.animationGraphics = spellAnimation;
		
		//Set sound
		AudioClip soundEffect = Resources.Load("Spells/Sound Effects/" + spellName) as AudioClip;
		energySphere.audio.clip = soundEffect;
		
		//Makes the sphere move
		energySphere.rigidbody2D.velocity = transform.TransformDirection(direction * Mathf.Max(spellData["speed"].AsFloat,minSpeed));

		lastSpell = Time.time;
	}
}
