using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class GameInstance : MonoBehaviour 
{
	private static GameInstance _instance;

	//Objects database
	private JSONNode spells;
	private JSONNode enemies;
	private JSONNode gameData;
	private JSONNode talking;

	//Black mood
	public GameObject blackMood;
	public Camera mainCamera;

	//Tests and various stuff
	public static string text_to_show = "Yoshi"; 
	public static bool show_text = true;

	//Object references
	private GameObject player;
	private GameObject cameraSystem;
	private UserInterface userInterface;

	//Player data
	private int level, health, maxHealth, mana, maxMana, experience, maxExperience;
	private float playerColliderRadius;

	//Time variables
	private float lastSpell, lastRegeneration, lastBattle = 0f;


	//Instance management
	public static GameInstance instance
	{
		get
		{
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			//DontDestroyOnLoad(this);

			//GET OTHER OBJECTS
			getObjectReferences();

			//SETUP SPELLS DATABASE
			TextAsset spellsJson = Resources.Load("SpellsDatabase") as TextAsset;
			spells = JSONNode.Parse(spellsJson.text);

			//SETUP ENEMIES DATABASE
			TextAsset enemiesJson = Resources.Load("EnemiesDatabase") as TextAsset;
			enemies = JSONNode.Parse(enemiesJson.text);

			//SETUP TALKING DATABASE
			TextAsset TalkJson = Resources.Load("TalkDatabase") as TextAsset;
			talking = JSONNode.Parse(TalkJson.text);


			//Setup player data
			experience = 95;
			setPlayerLevel (2);
			mana = maxMana;
			health = maxHealth;
			
			//startAllScripts();
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	void Start() {
		refreshUI();
		GameObject.FindWithTag ("GameSystem").gameObject.tag = "GameSystemActive";
	}

	//public bool isInBattle() {
	//	return battleTime > 5f;
	//}

	private void setPlayerLevel (int lev) {
		level = lev;
		//1 + Mathf.Clamp(Mathf.FloorToInt (Mathf.Sqrt ((experience - 100)/10)),0,99);
		maxExperience = 100 + 10 * (int) Mathf.Pow ((level-1),2f);
		maxHealth = 80 + 8 * (int) Mathf.Pow ((level-1),2f);
		maxMana = 200 + 12 * (int) Mathf.Pow ((level-1),2f);
		Debug.Log ("Player level: " + level);
		Debug.Log ("Health: " + maxHealth + ", Mana: " + maxMana);
	}

	private void getObjectReferences() {
		player = GameObject.FindWithTag ("Player");
		BoxCollider2D collider = player.GetComponent<BoxCollider2D> () as BoxCollider2D;
		playerColliderRadius = Mathf.Max (collider.size.x, collider.size.y);

		cameraSystem = GameObject.FindWithTag ("CameraSystem");
		//userInterface = UserInterface.instance;
		userInterface = GameObject.FindWithTag ("UserInterface").GetComponent("UserInterface") as UserInterface;
	}

	//Loads new map
	public void loadMap(string mapName, float xPosition, float yPosition) {
		Application.LoadLevel (mapName);
		player.transform.position = new Vector3 (xPosition, yPosition, 0f);
		cameraSystem.transform.position = new Vector3 (xPosition, yPosition, 0f);
	}

	//Casts a spell using position and directions as parameters
	public void castSpell(string spellName, Transform transform, Vector2 direction, string spellTag, float distance, float minSpeed) {
		//Check if spell is available
		if (spellName == null) return;
		JSONNode spellData = spells[spellName];
		if (spellData == null) return;

		//Instances an energy sphere
		GameObject spellPrefab = Resources.Load("Spells/" + spellData["color"] + "Spell") as GameObject;
		GameObject energySphere = (GameObject) Instantiate(spellPrefab, (transform.position + (new Vector3(direction.x, direction.y, 0)*distance)), new Quaternion(0,0,0,1));
		energySphere.tag = spellTag; 

		//Set spell parameters
		Spell spellParameters = (Spell) energySphere.GetComponent("Spell");
		spellParameters.damage = spellData["damage"].AsInt;
		spellParameters.duration = spellData["duration"].AsFloat;
		spellParameters.rigidbody2D.mass = spellData["mass"].AsInt;

		//Set animation
		GameObject spellAnimation = Resources.Load("Spells/Animations/" + spellName) as GameObject;
		spellParameters.animationGraphics = spellAnimation;

		//Set sound
		AudioClip soundEffect = Resources.Load("Spells/Sound Effects/" + spellName) as AudioClip;
		energySphere.audio.clip = soundEffect;

		//Makes the sphere move
		energySphere.rigidbody2D.velocity = transform.TransformDirection(direction * Mathf.Max(spellData["speed"].AsFloat,minSpeed));
	}

	public void meleeAttack(string meleeName, int enemyAttack, Vector2 forceDirection) {
		//Load animation
		GameObject meleePrefab = Resources.Load("Melees/Animations/" + meleeName) as GameObject;
		GameObject melee = (GameObject) Instantiate(meleePrefab, player.transform.position, new Quaternion(0,0,0,1));

		//Set sound
		melee.audio.clip = Resources.Load("Melees/Sound Effects/" + meleeName) as AudioClip;

		player.rigidbody2D.AddForce (forceDirection*enemyAttack*100);
		damagePlayer (enemyAttack);
	}

	public void playAudio(string name) {
		AudioClip soundEffect = Resources.Load("Audio/" + name) as AudioClip;
		audio.clip = soundEffect;
		audio.Play();
	}

	public void playMusic(string name) {
		AudioClip soundEffect = Resources.Load("Music/" + name) as AudioClip;
		audio.clip = soundEffect;
		audio.Play();
	}

	public void damagePlayer(int damage) {
		int randomModification = damage / 10;
		int levelModification = damage / 100;
		int finalDamage = damage + Random.Range(-randomModification,randomModification) - levelModification*(getPlayerLevel()-1);
		health = health - finalDamage;
		if (health <= 0) {
			health = 0;
			updateLifeBar();
			gameOver ();
			return;
		}
		//setBlackMood ((float) health / maxHealth);
		updateLifeBar ();
	}

	public void playerCastSpell(string spellName, Transform transform, Vector2 direction) {
		//Check if enough mana and if time has passed
		if (mana > spells [spellName] ["mana"].AsInt && Time.time>lastSpell+0.3f) {
				mana -= spells [spellName] ["mana"].AsInt;
				updateManaBar ();
				castSpell (spellName, transform, direction, "Spell", playerColliderRadius/2+(playerColliderRadius/10), 0f);
				lastSpell = Time.time;
		} else {
			//Not enough mana
		}
	}

	public void updateLifeBar () {
		userInterface.setHealthValue((float) health / maxHealth);
	}

	public void updateManaBar () {
		userInterface.setManaValue((float) mana / maxMana);
	}

	public void updateExpBar () {
		userInterface.setExpValue((float) experience / maxExperience);
	}

	public void refreshUI() {
		updateLifeBar ();
		updateManaBar ();
		updateExpBar ();
		userInterface.setLevel (level);
	}

	public void setBlackMood(float amount) {
		if (amount < 0.5f) {
			amount = amount / 0.5f;
			blackMood.transform.localScale = new Vector3 (Mathf.Clamp (amount * 1.5f, 0.4f, 1.5f), Mathf.Clamp (amount * 1.5f, 0.4f, 1.5f), 0);
			mainCamera.orthographicSize = Mathf.Clamp (2.5f + amount * 5f, 2f, 5f);
		}
	}
	
	public void gameOver() {
		//stopAllScripts ();
		Destroy (player);
		Destroy (GameObject.FindWithTag("GameSystemActive").gameObject);
		Destroy (this);
		Application.LoadLevel ("Game Over");
	}

	public JSONNode getEnemyParameters(string name) {
		return enemies[name];
	}

	public JSONNode getNPCTalkingParameters(string name) {
		return talking[name];
	}


	public void saveGame() {
		TextAsset gameJson = Resources.Load("GameData") as TextAsset;
		gameData = JSONNode.Parse(gameJson.text);
		gameData["scene"].AsInt = Application.loadedLevel;
		gameData ["health"].AsInt = health;
		gameData ["experience"].AsInt = experience;
		gameData ["xPosition"].AsFloat = player.transform.position.x;
		gameData ["yPosition"].AsFloat = player.transform.position.y;
		Debug.Log (gameData);
		System.IO.File.WriteAllText("Assets/Resources/GameData.json",gameData.ToString());
	}

	public void loadGame() {
		string gameJsonText = System.IO.File.ReadAllText("Assets/Resources/GameData.json");
		//TextAsset gameJson = Resources.Load("GameData") as TextAsset;
		gameData = JSONNode.Parse(gameJsonText);

		//Load scene & set parameters
		Application.LoadLevel (gameData["scene"].AsInt);

		setPlayerLevel (gameData["level"].AsInt);
		experience = gameData["experience"].AsInt;
		health = gameData["health"].AsInt;
		mana = gameData["mana"].AsInt;
		player.transform.position = new Vector3(gameData["xPosition"].AsFloat,gameData["yPosition"].AsFloat,0);
		cameraSystem.transform.position = new Vector3(gameData["xPosition"].AsFloat,gameData["yPosition"].AsFloat,0);


	}

	public void stopAllScripts() {
		MonoBehaviour[] scripts = (MonoBehaviour[]) FindObjectsOfTypeAll(typeof(MonoBehaviour));
		foreach (MonoBehaviour script in scripts) {
			//if(script == this) continue;
			if(script.gameObject.tag == "Enemy") script.enabled = false;
		}
	}

	public void startAllScripts() {
		MonoBehaviour[] scripts = (MonoBehaviour[]) FindObjectsOfTypeAll(typeof(MonoBehaviour));
		foreach (MonoBehaviour script in scripts) {
			if(script == this) continue;
			script.enabled = true;
		}
	}

	public void alwaysRegenerateMana() {
		mana = mana + Mathf.RoundToInt(maxMana / 20);
		if (mana > maxMana)	mana = maxMana;
		updateManaBar ();
	}

	public void regenerateMana() {
		mana = mana + Mathf.RoundToInt(maxMana / 10);
		if (mana > maxMana)	mana = maxMana;
		updateManaBar ();
	}

	public void regenerateHealth() {
		health = health + Mathf.RoundToInt(maxHealth / 10);
		if (health > maxHealth)	mana = maxHealth;
		updateLifeBar ();
		setBlackMood ((float) health / maxHealth);
	}

	public void damageValueAnimation(int damageValue, Vector3 position) {
		GameObject damageValuePrefab = Resources.Load("UI/Damage") as GameObject;
		GameObject damageValueText = (GameObject) Instantiate(damageValuePrefab, position, Quaternion.Euler(new Vector3(0,0,0)));
		DamageValue damageValueScript = (DamageValue) damageValueText.GetComponent("DamageValue");
		damageValueScript.damageValue = damageValue;
	}

	public GameObject showNPCText(string text, Vector3 position) {
		GameObject textPrefab = Resources.Load("UI/FloatingText") as GameObject;
		GameObject displayText = (GameObject) Instantiate(textPrefab, position, Quaternion.Euler(new Vector3(0,0,0)));
		FloatingText textScript = (FloatingText) displayText.GetComponent("FloatingText");
		textScript.message = text;
		//displayText.transform.position.x -= displayText.renderer.bounds.size.x / 2f;
		//GameObject finalText = displayText;
		return displayText;
	}

	public void playAnimation(string animationName, Vector3 position) {
		GameObject animationPrefab = Resources.Load("Animations/" + animationName) as GameObject;
		GameObject animation = (GameObject) Instantiate(animationPrefab, position, new Quaternion(0,0,0,1));
	}

	public void increaseExperience(int amount) {
		experience += amount;
		if (experience >= maxExperience) {
			experience = experience - maxExperience;
			levelUp();
		}
		updateExpBar ();
	}

	private void levelUp() {
		setPlayerLevel (level + 1);
		mana = maxMana;
		health = maxHealth;
		playAnimation ("Level Up",player.transform.position);
		refreshUI ();
	}

	public int getPlayerLevel() {
		return level;
	}

	public float getSpellRange(string spellName) {
		return spells[spellName]["duration"].AsFloat * spells[spellName]["speed"].AsFloat;
	}

	public bool regeneration() {
		if (health>0 && Time.time > lastSpell + 3f && Time.time > lastRegeneration + 3f) {
			if(mana < maxMana) regenerateMana();
			if(health < maxHealth) regenerateHealth ();
			lastRegeneration = Time.time;
			return true;
		}
		return false;
	}

	public bool isInBattle() {
		return lastBattle != 0 && Time.time < lastBattle + 5f;
	}
}