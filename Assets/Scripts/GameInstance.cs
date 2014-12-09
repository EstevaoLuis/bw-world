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

	//Black mood
	public GameObject blackMood;
	public Camera mainCamera;

	//Tests and various stuff
	public Slider lifeBar,manaBar;
	public static string text_to_show = "Yoshi"; 
	public static bool show_text = true;

	//Player data
	public GameObject player;
	private int health, maxHealth, mana, maxMana;

	//Time variables
	private float lastSpell, lastRegeneration;

	//Camera system
	public GameObject cameraSystem;

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
			DontDestroyOnLoad(this);

			//SETUP SPELLS DATABASE
			TextAsset spellsJson = Resources.Load("SpellsDatabase") as TextAsset;
			spells = JSONNode.Parse(spellsJson.text);

			//SETUP ENEMIES DATABASE
			TextAsset enemiesJson = Resources.Load("EnemiesDatabase") as TextAsset;
			enemies = JSONNode.Parse(enemiesJson.text);

			//Setup player data
			maxHealth = 200;
			health = maxHealth;
			maxMana = 300;
			mana = maxMana;

			startAllScripts();

			refreshUI();
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}


	//Casts a spell using position and directions as parameters
	public void castSpell(string spellName, Transform transform, Vector2 direction, string spellTag) {
		//Check if spell is available
		if (spellName == null) return;
		JSONNode spellData = spells[spellName];
		if (spellData == null) return;

		//Instances an energy sphere
		GameObject spellPrefab = Resources.Load("Spells/" + spellData["color"] + "Spell") as GameObject;
		GameObject energySphere = (GameObject) Instantiate(spellPrefab, (transform.position + new Vector3(direction.x, direction.y, 0)), transform.rotation);
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
		energySphere.rigidbody2D.velocity = transform.TransformDirection(direction * spellData["speed"].AsFloat);
	}

	public void playAudio(string name) {
		AudioClip soundEffect = Resources.Load("Spells/Sound Effects/" + name) as AudioClip;
		audio.clip = soundEffect;
		audio.Play();
	}

	public void damagePlayer(int damage) {
		health = health - damage;
		Debug.Log (health);
		if (health <= 0) {
			health = 0;
			updateLifeBar();
			gameOver ();
			return;
		}
		setBlackMood ((float) health / maxHealth);
		updateLifeBar ();
	}

	public void playerCastSpell(string spellName, Transform transform, Vector2 direction) {
		//Check if enough mana and if time has passed
		if (mana > spells [spellName] ["mana"].AsInt && Time.time>lastSpell+0.3f) {
				mana -= spells [spellName] ["mana"].AsInt;
				updateManaBar ();
				castSpell (spellName, transform, direction, "Spell");
				lastSpell = Time.time;
		} else {
			//Not enough mana
		}
	}

	public void updateLifeBar () {
		lifeBar.value = (float) health / maxHealth;
	}

	public void updateManaBar () {
		manaBar.value = (float) mana / maxMana;
	}

	public void refreshUI() {
			updateLifeBar ();
	}

	public void setBlackMood(float amount) {
		if (amount < 0.5f) {
			amount = amount / 0.5f;
			blackMood.transform.localScale = new Vector3 (Mathf.Clamp (amount * 1.5f, 0.4f, 1.5f), Mathf.Clamp (amount * 1.5f, 0.4f, 1.5f), 0);
			mainCamera.orthographicSize = Mathf.Clamp (2.5f + amount * 5f, 2f, 5f);
		}
	}
	
	public void gameOver() {
		stopAllScripts ();
		Destroy (player);
	}

	public JSONNode getEnemyParameters(string name) {
		return enemies[name];
	}

	public void saveGame() {
		TextAsset gameJson = Resources.Load("GameData") as TextAsset;
		gameData = JSONNode.Parse(gameJson.text);
		gameData["scene"].AsInt = Application.loadedLevel;
		gameData ["health"].AsInt = health;
		gameData ["xPosition"].AsFloat = player.transform.position.x;
		gameData ["yPosition"].AsFloat = player.transform.position.y;
		Debug.Log (gameData);
		System.IO.File.WriteAllText("Assets/Resources/GameData.json",gameData.ToString());
	}

	public void loadGame() {
		UnityEditor.AssetDatabase.Refresh (); 
		TextAsset gameJson = Resources.Load("GameData") as TextAsset;
		gameData = JSONNode.Parse(gameJson.text);

		//Load scene & set parameters
		Application.LoadLevel (gameData["scene"].AsInt);
		maxHealth = gameData["health"].AsInt;
		health = maxHealth;
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

	public void regenerateMana() {
		mana = mana + Mathf.RoundToInt(maxMana / 10);
		if (mana > maxMana)	mana = maxMana;
		updateManaBar ();
	}

	void Update() {
		if (Time.time > lastSpell + 2f && Time.time > lastRegeneration + 3f) {
			regenerateMana();
			lastRegeneration = Time.time;
		}
	}

}