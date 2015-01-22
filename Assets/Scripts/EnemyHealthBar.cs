using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

	private EnemyController controller;
	public GameObject enemy;
	private Slider health;
	//public Canvas canvas;
	public Camera camera;

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
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy == null || controller.getHealth() <= 0) {
				Debug.Log ("killed!");	
				Destroy (gameObject);
		}

		//health.transform.position = enemy.transform.position;
		//canvas.transform.position = enemy.transform.position;
		//Vector3 newPosition = (new Vector3(0.0f, -200.0f, 0.0f) + enemy.transform.position);
		//Vector3 newPosition = enemy.transform.position + new Vector3(0, 3);
		Vector3 newPosition = enemy.transform.position + 2.8f * Vector3.up;
		//Vector3 newPosition = (new Vector3(enemy.transform.position.x + 50.0f, enemy.transform.position.y - 200.0f) + enemy.transform.position);
		health.transform.position = (camera.WorldToScreenPoint (newPosition));
		health.value = controller.getHealth ();
	}
}
