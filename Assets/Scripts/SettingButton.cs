﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {

	public void SettingWindow() {
		UIManager.getInstance ().ShowSettingPanel ();
	}
}