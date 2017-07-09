using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour {
	private static HeroManager instance;
	public Image heroImg;
	private int spriteNum = 2;
	private int heroSpeed = 10;
	private int upDownSpeed = 0;
	private bool isRight = true;

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
		Vector3 vec = heroImg.transform.localScale;

		if (isRight) {
			vec.x = Mathf.Abs (vec.x);
			heroImg.transform.localScale = vec;
		} else {
			vec.x = -Mathf.Abs (vec.x);
			heroImg.transform.localScale = vec;
		}

		heroImg.sprite = Resources.Load<Sprite> ("Hero/hero_0" + spriteNum) as Sprite;

		if (upDownSpeed != 0) {
			heroImg.transform.Translate (heroSpeed, upDownSpeed, 0);
			upDownSpeed = 0;
		} else {
			heroImg.transform.Translate (heroSpeed, upDownSpeed, 0);
		}
			
		spriteNum++;

		if (spriteNum > 6) {
			spriteNum = 1;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		isRight = !isRight;
		upDownSpeed = -50;
		heroSpeed *= -1;
	}
}
