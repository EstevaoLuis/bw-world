using UnityEngine;
using System.Collections;

public class ExplosionColorGem : MonoBehaviour {

	private SpriteRenderer sprite;
	public string color = "green";
	public float intensity = 0.1f;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void kolorMe(){
		//Color kolor = sprite.color;
		float red = sprite.color.r;
		float green = sprite.color.g;
		float blue = sprite.color.b;
		//float alpha = sprite.color.a;
		bool destructionBool = false;


		Debug.Log ("RGB: " + red + " " + green + " " + blue);

		if (color != "red")	red = red - intensity;
		if (color != "blue") blue = blue - intensity;
		if (color != "green") green = green - intensity;

		Debug.Log ("RGB: " + red + " " + green + " " + blue);

		if (red <= 0f || green <= 0f || blue <= 0f) {
			red = 0f;
			blue = 0f;
			destructionBool = true;
		}

		Debug.Log ("RGB: " + red + " " + green + " " + blue);

		sprite.color = new Color (red, green, blue);

		if (destructionBool)
			Destroy (gameObject);
			//gameObject.SetActive (false);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Spell") {
			Spell spellParameters = (Spell)other.gameObject.GetComponent ("Spell");
			string kolor = spellParameters.color;
			
			if (kolor.Equals(color)){
				kolorMe();
			}
		}
	}
}
