using UnityEngine;
using System.Collections;
using SimpleJSON;

public class GameInstance : MonoBehaviour 
{
	private static GameInstance _instance;

	//Objects database
	private JSONNode spells;
	private JSONNode enemies;

	//Tests and various stuff
	public TextMesh healthText = null;
	public static string text_to_show = "Yoshi"; 
	public static bool show_text = true;

	//Player data
	private int health;

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
			health = 200;
		
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
	public void castSpell(string spellName, Transform transform, Vector2 direction, string tag) {
		JSONNode spellData = spells[spellName];
		Debug.Log(spellName);
		if(spellData != null) {

			//Instances an energy sphere
			GameObject spellPrefab = Resources.Load("Spells/" + spellData["color"] + "Spell") as GameObject;
			GameObject energySphere = (GameObject) Instantiate(spellPrefab, (transform.position + new Vector3(direction.x, direction.y, 0)), transform.rotation);
			energySphere.tag = tag;

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
	}

	public void playAudio(string name) {
		AudioClip soundEffect = Resources.Load("Spells/Sound Effects/" + name) as AudioClip;
		audio.clip = soundEffect;
		audio.Play();
	}

	public void damagePlayer(int damage) {
		health = health - damage;
		if (health <= 0) {
			gameOver ();
			return;
		}
		updateLifeBar ();
	}

	public void updateLifeBar () {
		healthText.text = "Life: " + health;
	}

	
	public void gameOver() {

	}

	public JSONNode getEnemy(string name) {
		return enemies[name];
	}

	/*
	 * //THow to use
		GameInstance instance = GameInstance.instance;
		instance.Test();
	 * 
	 * 
	 */



}