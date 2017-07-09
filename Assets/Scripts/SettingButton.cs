using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {

	public void ShowSetting() {
		UIManager.getInstance ().ShowSettingPanel ();
	}

	public void HideSetting() {
		UIManager.getInstance ().HideSettingPanel ();
	}

	public void BGMVolumeChange(float vol) {
		AudioManager.getInstance ().bgmSource.volume = vol;
	}

	public void SFXVolumeChange(float vol) {
		AudioManager.getInstance ().sfxSource.volume = vol;
	}
}