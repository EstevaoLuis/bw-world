using UnityEngine;
using System.Collections;

public class CreateDecoloringSpider : MonoBehaviour {

	public GameObject toBeKilled;

	private PlayerController player;
	private GameObject spider;
	private EnemyController spiderController;
	private bool spiderInstantiated = false;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		player.isAvailable (false);
		QuestManager.instance.startEvent("Decoloring");
		Invoke ("createSpider", 3f);
	}


	void Update() {
		if(spiderInstantiated) {
			if(spiderController.getHealth() <= 0 || spider == null) {
				QuestManager.instance.endEvent("Decoloring");
				QuestManager.instance.startEvent("To the forest");
				Debug.Log ("Nemico ucciso!!");
				this.enabled = false;
			}
			Debug.Log (spiderController.getHealth());
		}
	}

	void createSpider() {
		Vector3 newPosition = new Vector3 (toBeKilled.transform.position.x + 5f, toBeKilled.transform.position.y + 2f, 0f);
		GameInstance.instance.playAnimation ("Appear",newPosition);
		spider = GameInstance.instance.instantiateEnemy ("Spider","Spider",newPosition);
		spiderController = spider.GetComponent<EnemyController>();
		GameInstance.instance.castSpell ("Black 3", spider.transform, new Vector2 (-1f, 0f), "SpellEnemy", 0f, 0f, 0);
		spiderInstantiated = true;
		Invoke ("displayMessage", 2f);
	}

	void displayMessage() {
		Destroy (toBeKilled);
		player.isAvailable (true);
		UserInterface.instance.displayMessage ("Hurry up, stop the spider!!");
	}

}
