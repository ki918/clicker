using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour {
	private static HeroManager instance;
	public Image heroImg;
	public Material background;

	private int spriteNum = 2;
	private float heroAnimationSpeed = 0.03f;
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

	void Start() {
		// moveHero 함수 시작
		StartCoroutine ("moveHero");
	}

	void Update() {
		// 배경화면 스크롤링
		Vector2 vec = background.mainTextureOffset;
		vec.Set (vec.x + (1 * Time.deltaTime), 0);
		background.mainTextureOffset = vec;
	}

	/**
	 * 주인공 애니메이션
	 * */
	IEnumerator moveHero() {
		while (true) {
			Vector3 vec = heroImg.transform.localScale;

			if (isRight) {
				vec.x = Mathf.Abs (vec.x);
				heroImg.transform.localScale = vec;
			} else {
				vec.x = -Mathf.Abs (vec.x);
				heroImg.transform.localScale = vec;
			}

			heroImg.sprite = Resources.Load<Sprite> ("Hero/hero_0" + spriteNum) as Sprite;
				
			spriteNum++;

			if (spriteNum > 6) {
				spriteNum = 1;
			}

			yield return new WaitForSeconds (heroAnimationSpeed);
		}
	}

	/**
	 * 충돌 판정
	 * */
	void OnTriggerEnter2D(Collider2D collider) {
		isRight = !isRight;
	}
}
