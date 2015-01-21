using UnityEngine;
using System.Collections;

public class MeteorArea : MonoBehaviour {

	public float areaSize;
	public float generationPeriod = 5f;
	public float waitBeforeInstantiating = 3f;

	private float lastGeneration = 0f;
	private GameObject meteorPrefab;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		meteorPrefab = (GameObject) Resources.Load ("Events/Meteor");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastGeneration + generationPeriod) {
			newPosition = new Vector3(transform.position.x + Random.Range(-areaSize,areaSize)+4f,transform.position.y + Random.Range(-areaSize,areaSize)+6f,-2f);
			//GameInstance.instance.playAnimation("Target",new Vector3(newPosition.x-4f,newPosition.y-6.5f,-1f));
			Invoke("instantiateMeteor",waitBeforeInstantiating);
			lastGeneration = Time.time;
		}
	}

	private void instantiateMeteor() {
		Instantiate(meteorPrefab, newPosition, new Quaternion(0,0,0,1));
	}
}
