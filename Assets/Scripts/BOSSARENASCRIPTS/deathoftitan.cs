using UnityEngine;
using System.Collections;

public class deathoftitan : MonoBehaviour {

	public string teleportPrefabName = "Teleport";
	public string finalAttackName = "Wind Attack";

	private PlayerController controller;
	private EnemyController enemy;
	private bool isActivated = false;

	// Use this for initialization
	void Start () {
	
		enemy = GetComponent<EnemyController> ();
		controller = GameInstance.instance.getPlayerController ();

	}
	
	// Update is called once per frame
	void Update () {
		if (enemy.getHealth () <= 0 && !isActivated) {
			isActivated = true;
			GameInstance.instance.playAudio("Darkness8");
			Invoke ("activateTeleport",3f);
			Debug.Log ("Boss sconfitto");
			GameInstance.instance.setBossBattle(false);
			GameInstance.instance.playAnimation(finalAttackName,new Vector3(transform.position.x,transform.position.y-4f,0f));
			Object prefab2 = Resources.Load("Events/" + teleportPrefabName) as Object;
			Instantiate(prefab2,new Vector3(transform.position.x,transform.position.y,0.1f), new Quaternion(0f,0f,0f,1f));
			GameInstance.instance.playAudio("Victory1");
			QuestManager.instance.setNewTarget(new Vector3(transform.position.x,transform.position.y,0.1f));
		}

	}
	
}
