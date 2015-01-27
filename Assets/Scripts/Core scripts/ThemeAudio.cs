using UnityEngine;
using System.Collections;

public class ThemeAudio : MonoBehaviour {

	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;

	private float fromVolume1, fromVolume2, fromVolume3;
	private float toVolume1, toVolume2, toVolume3;

	//Audio
	private AudioClip sceneAudio, battleAudio, bossAudio;
	private bool isBattleTheme = false;
	private float crossfadeTime;
	private float transitionTime = 4f;
	private bool isBossFight = false;

	// Use this for initialization
	void Start () {
		//sceneAudio = Resources.Load ("Music/Field4") as AudioClip;
		selectSceneAudio ();
		battleAudio = Resources.Load ("Music/Battle4") as AudioClip;
		bossAudio = Resources.Load ("Music/Battle3") as AudioClip;
		audio1.clip = sceneAudio;
		audio2.clip = battleAudio;
		audio3.clip = bossAudio;
		audio1.Play ();
		audio1.volume = 1f;
		fromVolume1 = 1f;
		toVolume1 = 1f;
		audio2.Play ();
		audio2.volume = 0f;
		fromVolume2 = 0f;
		toVolume2 = 0f;
		audio3.Play ();
		audio3.volume = 0f;
		fromVolume3 = 0f;
		toVolume3 = 0f;
	}

	void OnLevelWasLoaded(int level) {
		selectSceneAudio ();
		audio1.Play ();
	}

	private void selectSceneAudio() {
		string audioName;
		switch (Application.loadedLevelName) {
		case "Green World": audioName = "Field4"; break;
		case "Blue World": audioName = "Theme2"; break;
		case "Red World": audioName = "Dungeon5"; break;
		default: audioName = "Field4"; break;
		}
		sceneAudio = Resources.Load ("Music/" + audioName) as AudioClip;
		audio1.clip = sceneAudio;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameInstance.instance.isBossBattle()) {
			if(!isBossFight) {
				playBossTheme();
			}
		}
		else {
			if(isBossFight) {
				stopBossTheme();
			}
			if (GameInstance.instance.isInBattle ()) {
				if(!isBattleTheme) playBattleTheme();
			} else {
				if(isBattleTheme) playSceneTheme();
			}
		}
		audio1.volume = Mathf.Clamp01 (Mathf.Lerp(fromVolume1,toVolume1,(Time.time - crossfadeTime) / transitionTime));
		audio2.volume = Mathf.Clamp01 (Mathf.Lerp(fromVolume2,toVolume2,(Time.time - crossfadeTime) / transitionTime));
		audio3.volume = Mathf.Clamp01 (Mathf.Lerp(fromVolume3,toVolume3,(Time.time - crossfadeTime) / transitionTime));
	}
	
	public void stopAudio() {
		audio1.Stop ();
		audio2.Stop ();
	}

	private void playSceneTheme() {
		isBattleTheme = false;
		crossfadeTime = Time.time;
		Debug.Log ("Back to normal audio theme");
		fromVolume1 = audio1.volume;
		fromVolume2 = audio2.volume;
		toVolume1 = 1f;
		toVolume2 = 0f;
		
	}
	
	private void playBattleTheme() {
		isBattleTheme = true;
		crossfadeTime = Time.time;
		Debug.Log ("Battle theme");
		fromVolume1 = audio1.volume;
		fromVolume2 = audio2.volume;
		toVolume1 = 0f;
		toVolume2 = 1f;
	}

	public void playBossTheme() {
		isBossFight = true;
		toVolume1 = 0f;
		toVolume2 = 0f;
		toVolume3 = 1f;
		fromVolume1 = audio1.volume;
		fromVolume2 = audio2.volume;
		fromVolume3 = audio3.volume;
		crossfadeTime = Time.time;
	}

	public void stopBossTheme() {
		isBossFight = false;
		isBattleTheme = false;
		toVolume1 = 1f;
		toVolume2 = 0f;
		toVolume3 = 0f;
		fromVolume1 = audio1.volume;
		fromVolume2 = audio2.volume;
		fromVolume3 = audio3.volume;
		crossfadeTime = Time.time;
	}

	public void playTheme(string name) {
		AudioClip newTheme = Resources.Load ("Music/" + name) as AudioClip;
		Debug.Log (newTheme);
	}

}
