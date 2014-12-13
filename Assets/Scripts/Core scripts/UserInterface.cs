using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class UserInterface : MonoBehaviour 
{
	private static UserInterface _instance;

	//UI objects
	private Slider healthBar;
	private Slider manaBar;
	private Slider expBar;
	
	//Instance management
	public static UserInterface instance
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
			_instance = this;

			//GET OTHER OBJECTS
			getObjectReferences();

		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	private void getObjectReferences() {
		healthBar = GameObject.FindWithTag ("HealthBar").GetComponent<Slider>() as Slider;
		manaBar = GameObject.FindWithTag ("ManaBar").GetComponent<Slider>() as Slider;
		expBar = GameObject.FindWithTag ("ExpBar").GetComponent<Slider>() as Slider;
	}

	public void setHealthValue(float value) {
		healthBar.value = Mathf.Clamp (value, 0, 1);
	}

	public void setManaValue(float value) {
		manaBar.value = Mathf.Clamp (value, 0, 1);
	}

	public void setExpValue(float value) {
		expBar.value = Mathf.Clamp (value, 0, 1);
	}

}