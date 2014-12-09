using UnityEngine;
using System.Collections;

public class DamageValue : MonoBehaviour {

	public float duration = 1.0f;	
	public float transition = 0.5f;	
	public int damageValue = 0;

	private float time = 0.0f;
	private float hidden = 1f;
	private float visible = 20f;
	private Vector3 direction;
	
	private TextMesh damageText;

	// Use this for initialization
	void Start () {
		damageText = GetComponent<TextMesh> ();
		damageText.text = damageValue.ToString();
		direction = new Vector3 (Random.Range (-0.5f, 0.5f), Random.Range (0.5f, 1f), 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * Time.deltaTime;

		if(time > duration+transition) {
			Destroy (gameObject);
		}
		else if (time > duration) {
			damageText.fontSize = Mathf.RoundToInt(Mathf.Lerp(visible,hidden,(time-duration)/transition));
			time += Time.deltaTime;
		}
		time += Time.deltaTime;
	}
}
