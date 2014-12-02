using UnityEngine;
using System.Collections;
using SimpleJSON;

public class GameInstance : MonoBehaviour 
{
	private static GameInstance _instance;

	public TextMesh healthText = null;
	private JSONNode spells;

	public static string text_to_show = "Yoshi"; 
	public static bool show_text = true;


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
			//Debug.Log(spells["Fire 2"]["mass"]);

		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}
	
	public void setHealth(int health) {
		healthText.text = "Life: " + health;
	}

	/*
	 * //THow to use
		GameInstance instance = GameInstance.instance;
		instance.Test();
	 * 
	 * 
	 */



}