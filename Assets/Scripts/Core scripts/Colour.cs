using UnityEngine;
using System.Collections;

public class Colour : MonoBehaviour {

	public bool isColoured = false;
	public float duration = 3.0f;

	private Color spriteColor;
	private float time = 0.0f; 
	private Color hidden = new Color (1, 1, 1, 0);
	private Color visible = new Color (1, 1, 1, 1);
	private Color compositeColor = new Color (0,0,0,1);

	private SpriteRenderer renderer;
	private Color lastColor;
	private Color finalColor;
	//private bool transition = false;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		if (isColoured) {
			renderer.color = hidden;
			finalColor = hidden;
			lastColor = hidden;

		} else {
			renderer.color = visible;
			finalColor = visible;
			lastColor = visible;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isTransition() && time <= duration+0.2f) {
			renderer.color = Color.Lerp(lastColor,finalColor,time/duration);
			time += Time.deltaTime;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "Spell") {
			Spell spell = other.gameObject.GetComponent("Spell") as Spell;
			/*
			if (isColoured && finalColor!=visible) {
				audio.Play();
			}
			*/
			color(spell.color);
		}
		else if(other.gameObject.tag == "SpellEnemy") {
			decolor ();
		}
	}

	void color(string spellColor) {
		lastColor = renderer.color;
		if (isColoured) {
			switch (spellColor) {
			case "red": if(compositeColor.r == 0) audio.Play (); compositeColor.r = 255; break;
			case "green": if(compositeColor.g == 0) audio.Play (); compositeColor.g = 255; break;
			case "blue": if(compositeColor.b == 0) audio.Play (); compositeColor.b = 255; break;
			}
			finalColor = compositeColor;//visible;
		} else {
			finalColor = hidden;
		}
		time = 0f;
	}

	void decolor() {
		lastColor = renderer.color;
		if (isColoured) {
			finalColor = hidden;
		} else {
			finalColor = visible;
		}
		time = 0f;
	}

	public bool isColored() {
		return isColoured && (renderer.color.r == 255 || renderer.color.g == 255 || renderer.color.b == 255); 
	}

	bool isTransition() {
		return renderer.color != finalColor;
	}
}
