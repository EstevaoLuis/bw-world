using UnityEngine;
using System.Collections;

public class ThemeAudio : MonoBehaviour {

	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;

	//Audio
	private AudioClip sceneAudio, battleAudio;
	private bool isBattleTheme = false;
	private float crossfadeTime;

	// Use this for initialization
	void Start () {
		sceneAudio = Resources.Load ("Music/Field4") as AudioClip;
		battleAudio = Resources.Load ("Music/Battle4") as AudioClip;
		audio1.clip = sceneAudio;
		audio2.clip = battleAudio;
		audio1.Play ();
		audio1.volume = 1f;
		audio2.Play ();
		audio2.volume = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameInstance.instance.isInBattle ()) {
			if(!isBattleTheme) playBattleTheme();
		} else {
			if(isBattleTheme) playSceneTheme();
		}
	}
	
	public void stopAudio() {
		audio1.Stop ();
		audio2.Stop ();
	}

	private void playSceneTheme() {
		isBattleTheme = false;
		crossfadeTime = Time.time;
		Debug.Log ("Back to normal audio theme");
		//audio.clip = sceneAudio;
		//audio.Play ();
		
	}
	
	private void playBattleTheme() {
		isBattleTheme = true;
		crossfadeTime = Time.time;
		Debug.Log ("Battle theme");
		//audio.clip = battleAudio;
		//audio.Play ();
	}

	public void playTheme(string name) {
		AudioClip newTheme = Resources.Load ("Music/" + name) as AudioClip;
		Debug.Log (newTheme);
		//audio.clip = newTheme;
		//audio.Play ();

	}
}
