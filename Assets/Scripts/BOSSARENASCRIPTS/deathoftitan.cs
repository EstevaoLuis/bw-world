using UnityEngine;
using System.Collections;

public class deathoftitan : MonoBehaviour {

	private EnemyController tit;
	public GameObject door;

	// Use this for initialization
	void Start () {
	
		tit = this.GetComponent<EnemyController> ();


	}
 	bool titan_death(){

		if (tit.getHealth () <= 0) {
			Destroy(door);
			return true;
		}

		return false;
	}
	
	// Update is called once per frame
	void Update () {
		titan_death ();

	}
}
