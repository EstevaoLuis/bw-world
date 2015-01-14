using UnityEngine;
using System.Collections;

public class IceSwordsRandom : MonoBehaviour {

	public GameObject IceSwords;
	private GameObject [] aux;
	private float timer = 2f;
	private float timer_2 = 2f;
	private int nam;
	private int pos = 1;
	// Use this for initialization
	void Start () {
		aux = new GameObject[20];
	}
	void random_generator_ice_sword(){

		Vector3 random_pos = new Vector3 (Random.Range (-10 + transform.position.x, transform.position.x + 10)
		                                  , Random.Range (-10 + transform.position.y, transform.position.y + 10));


		aux[pos] = (GameObject) Instantiate (IceSwords,random_pos, transform.rotation);
		pos++;
		//nam = nam - 1;

	}

	// Update is called once per frame
	void Update () {

		if (Time.time > timer) {
			random_generator_ice_sword();
			timer = timer + 2f;
			nam++;
			Destroy[aux[pos-1]];
		}
	}
}
//		if (Time.time > timer_2) {
//			DestroyImmediate(aux);
//			timer_2 = timer_2 + 4f;
//
//		}
