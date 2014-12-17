using UnityEngine;
using System.Collections;

public class Regeneration : MonoBehaviour {

	private float lastRegeneration = 0f;

	// Update is called once per frame
	void Update () {
		if (Time.time > lastRegeneration + 3.0f) {
			GameInstance.instance.alwaysRegenerateMana();
			lastRegeneration = Time.time;
		}
	}
}
