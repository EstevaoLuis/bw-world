using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class UserInterface : MonoBehaviour 
{
	private static UserInterface _instance;

	public GameObject messagePanel;
	public Text displayedMessage;
	public Text displayedName;

	//UI objects
	private Slider healthBar;
	private Slider manaBar;
	private Slider expBar;
	private Text levelText;
	private GameObject directionalArrow;
	private RectTransform arrowTransform;
	private GameObject textScrollbar;

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

			transform.position = new Vector3(0f,0f,0f);

			//GET OTHER OBJECTS
			getObjectReferences();
			closeMessagePanel ();
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

	}

	private void getObjectReferences() {
		healthBar = GameObject.FindWithTag ("HealthBar").GetComponent<Slider>() as Slider;
		manaBar = GameObject.FindWithTag ("ManaBar").GetComponent<Slider>() as Slider;
		expBar = GameObject.FindWithTag ("ExpBar").GetComponent<Slider>() as Slider;
		levelText = GameObject.FindWithTag ("LevelText").GetComponent<Text>() as Text;
		directionalArrow = GameObject.FindWithTag ("DirectionalArrow") as GameObject;
		directionalArrow.SetActive (false);
		arrowTransform = directionalArrow.GetComponent<RectTransform>();
		textScrollbar = GameObject.FindWithTag ("TextScrollbar") as GameObject;
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

	public void setLevel(int value) {
		levelText.text = value.ToString ();
	}

	public void setArrowDirection(float angle) {
		arrowTransform.eulerAngles = new Vector3 (0f,0f,angle-90f);
	}

	public void enableArrowDirection(bool isActive) {
		directionalArrow.SetActive (isActive);
	}

	public void displayMessage(string name, string text) {
		messagePanel.SetActive (true);
		//textScrollbar.SetActive (true);
		Debug.Log (text);
		displayedMessage.text = "\n" + text;
		if (name != null) displayedName.text = name;
	}

	public void closeMessagePanel() {
		messagePanel.SetActive (false);
	}

}