using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

	private EnemyController controller;
	public GameObject enemy;
	private Slider health;
	//public Canvas canvas;
	private Camera camera;

	// Use this for initialization
	void Start () {
		controller = enemy.GetComponent<EnemyController> ();
		health = GetComponent<Slider> ();

		Debug.Log ("ALEX KIDD");
		JSONNode parameters = GameInstance.instance.getEnemyParameters (controller.enemyName);
		Debug.Log ("DAVID DUNCAN");

		int life = parameters ["health"].AsInt;

		health.maxValue = life;
		//Debug.Log (controller.getHealth ());
		health.minValue = 0;
		health.value = life;

		//camera = (Camera)GameObject.Find ("Camera");
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy == null || controller.getHealth() <= 0) {
				Debug.Log ("killed!");	
				Destroy (gameObject);
		}

		Vector3 newPosition = enemy.transform.position + 2.8f * Vector3.up;
		health.transform.position = (camera.WorldToScreenPoint (newPosition));
		health.value = controller.getHealth ();
	}
}
