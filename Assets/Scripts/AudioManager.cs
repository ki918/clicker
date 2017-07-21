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

	/**
	 * 배경음악 재생 시작
	 * stage : 현재 스테이지 정보
	 * */
	public void playBGM(int stage) {
		bgmSource.clip = stageBGM [stage - 1];
		bgmSource.Play ();
	}

	/**
	 * 효과음 재생
	 * sfxNumber : 재생 할 효과음 번호
	 * */
	public void playSFX(int sfxNumber) {
		sfxSource.PlayOneShot (gameSFX [sfxNumber]);
	}

	/**
	 * 배경음악 음소거
	 * */
	public void muteBGM(bool flag) {
		bgmSource.mute = flag;
	}

	/**
	 * 효과음 음소거
	 * */
	public void meteSFX(bool flag) {
		sfxSource.mute = flag;
	}
}
