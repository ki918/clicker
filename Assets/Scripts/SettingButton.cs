using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {

	/**
	 * 환경설정 창 보여주기
	 * */
	public void ShowSetting() {
		UIManager.getInstance ().ShowSettingPanel ();
	}

	/**
	 * 환경설정 창 숨기기
	 * */
	public void HideSetting() {
		UIManager.getInstance ().HideSettingPanel ();
	}

	/**
	 * 배경음 볼륨 조절
	 * */
	public void BGMVolumeChange(float vol) {
		AudioManager.getInstance ().bgmSource.volume = vol;
	}

	/**
	 * 효과음 볼륨 조절
	 * */
	public void SFXVolumeChange(float vol) {
		AudioManager.getInstance ().sfxSource.volume = vol;

	}
}