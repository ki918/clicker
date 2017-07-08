using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour {
	public static HeroManager instance;
	public Image heroImg;

	public static HeroManager getInstance() {
		if (instance == null) {
			instance = FindObjectOfType<HeroManager> ();

			if (instance == null) {
				GameObject container = new GameObject ("HeroManager");

				instance = container.AddComponent<HeroManager> ();
			}
		}

		return instance;
	}

	public void moveHero() {
		heroImg.sprite = Resources.Load<Sprite> ("Hero/hero_02") as Sprite;
	}
}
