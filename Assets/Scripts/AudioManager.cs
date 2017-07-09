using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	private static AudioManager instance;
	public AudioSource bgmSource;
	public AudioSource sfxSource;
	public AudioClip[] stageBGM;
	public AudioClip[] gameSFX;

	public static AudioManager getInstance() {
		if (instance == null) {
			instance = FindObjectOfType<AudioManager> ();

			if (instance == null) {
				GameObject container = new GameObject ("AudioManager");

				instance = container.AddComponent<AudioManager> ();
			}
		}

		return instance;
	}

	void Start() {
		playBGM (1);
	}

	public void playBGM(int stage) {
		bgmSource.clip = stageBGM [stage - 1];
		bgmSource.Play ();
	}

	public void playSFX(int sfxNumber) {
		sfxSource.PlayOneShot (gameSFX [sfxNumber]);
	}

	public void muteBGM(bool flag) {
		bgmSource.mute = flag;
	}

	public void meteSFX(bool flag) {
		sfxSource.mute = flag;
	}
}
