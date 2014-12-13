using UnityEngine;
using System.Collections;

public class Regeneration : MonoBehaviour {

	private float lastRegeneration = 0f;

	// Update is called once per frame
	void Update () {
		if (Time.time > lastRegeneration + 3.0f) {
			if(GameInstance.instance.regeneration()) lastRegeneration = Time.time;
		}
	}
}
