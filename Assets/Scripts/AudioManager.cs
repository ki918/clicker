using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour {
	private static AudioManager instance;
	public AudioSource bgmSource;
	public AudioSource sfxSource;
	public AudioClip[] stageBGM;
	public AudioClip[] gameSFX;

	private const int INTRO_BGM = 0;
	private const int IN_GAME_BGM = 1;
	private const int CHNAGE_SCENE = 2;

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
		
	}

	/**
	 * 인게임 배경음악 재생 시작
	 * */
	public void playGameBGM() {
		bgmSource.clip = stageBGM [IN_GAME_BGM];
		bgmSource.Play ();
	}

	/**
	 * 인트로 배경음악 재생 시작
	 * */
	public void playIntroBGM() {
		bgmSource.clip = stageBGM [INTRO_BGM];
		bgmSource.Play ();
	}

	/**
	 * 씬 전환 배경음악 재생 시작
	 * */
	public void playChangeSceneBGM() {
		bgmSource.clip = stageBGM [CHNAGE_SCENE];
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
