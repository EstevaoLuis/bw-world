using UnityEngine;
using System.Collections;

public class deathoftitan : MonoBehaviour {

	private EnemyController tit;
	public GameObject cam;
	private CircleCollider2D r;

	// Use this for initialization
	void Start () {
	
		tit = this.GetComponent<EnemyController> ();
		r = cam.GetComponent<CircleCollider2D> ();

	}
 	bool titan_death(){

		if (tit.getHealth () <= 0) {
			Instantiate(cam,transform.position,transform.rotation);
			r.radius = 10;
			Destroy (gameObject);
			return true;
		}

		return false;
	}
	
	// Update is called once per frame
	void Update () {
		titan_death ();

	}
}
