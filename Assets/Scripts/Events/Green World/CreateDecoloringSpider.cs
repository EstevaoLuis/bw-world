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
		if(QuestManager.instance.getStoryLevel() == 11) {
			player = GameInstance.instance.getPlayerGameObject().GetComponent<PlayerController>();
			player.isAvailable (false);
			QuestManager.instance.startEvent("Decoloring");
			Invoke ("createSpider", 3f);
		}
	}


	void Update() {
		if(spiderInstantiated) {
			if(spiderController.getHealth() <= 0/* || spider == null*/) {
				QuestManager.instance.endEvent("Decoloring");
				QuestManager.instance.startEvent("To the forest");
				Debug.Log ("Nemico ucciso!!");
				this.enabled = false;
			}
			Debug.Log (spiderController.getHealth());
		}
	}

	void createSpider() {
		Vector3 newPosition = new Vector3 (toBeKilled.transform.position.x + 4f, toBeKilled.transform.position.y + 1f, 0f);
		GameInstance.instance.playAnimation ("Appear",new Vector3(newPosition.x, newPosition.y, 0.01f));
		spider = GameInstance.instance.instantiateEnemy ("Spider","Spider (Tutorial)",newPosition);
		spiderController = spider.GetComponent<EnemyController>();
		spiderInstantiated = true;
		Invoke ("displayMessage", 2f);
	}

	void displayMessage() {
		Destroy (toBeKilled);
		GameInstance.instance.castSpell ("Black 4", toBeKilled.transform, new Vector2 (-1f, 0f), "SpellEnemy", 0f, 0f, 0);
		player.isAvailable (true);
		UserInterface.instance.displayMessage ("Villager","Hurry up, stop the spider!!");
	}

}
