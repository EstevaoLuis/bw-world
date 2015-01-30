using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

	private EnemyController controller;
	public GameObject enemy;
	private Slider health;
	private Camera camera;
	public float barPosition;

	// Use this for initialization
	void Start () {
		//if (enemy == null) enemy = gameObject;
		controller = enemy.GetComponent<EnemyController> ();
		health = GetComponent<Slider> ();

		int life = controller.getHealth();

		health.maxValue = life;
		health.minValue = 0;
		health.value = life;

		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy == null || controller.getHealth() <= 0) {
				Debug.Log ("killed!");	
				Destroy (health);
		}
		if(camera == null) camera = Camera.main;
		Vector3 newPosition = enemy.transform.position + barPosition * Vector3.up;
		health.transform.position = (camera.WorldToScreenPoint (newPosition));
		health.value = controller.getHealth ();
	}
}
