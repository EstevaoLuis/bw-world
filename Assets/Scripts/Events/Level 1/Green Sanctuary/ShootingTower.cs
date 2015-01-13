using UnityEngine;
using System.Collections;

public class ShootingTower : MonoBehaviour {

	public float interval = 2f;
	public string spellName = "Black 1";
	public Vector2 direction = new Vector2(0f, -1f);

	private float lastSpell;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > lastSpell + interval) {
			GameInstance.instance.castSpell(spellName,transform,direction,"SpellEnemy",0f,0f,0);
			lastSpell = Time.time;
		}
	}
}
