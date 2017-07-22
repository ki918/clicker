using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour {
	private static HeroManager instance;
	public Image heroImg;

	private int spriteNum = 2;
	private float heroAnimationSpeed = 0.03f;

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

	/**
	 * 주인공 애니메이션
	 * */
	IEnumerator moveHero() {
		while (true) {
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
		
	}

	/**
	 * 아이템 줍기
	 * speed : 이동속도
	 * item : 아이템
	 * */
	public void moveToItem(float speed, GameObject item) {
		if (item != null) {
			float y = item.transform.localPosition.y;
			float height = ((RectTransform)item.transform).rect.height;
			y += height;

			if (y > heroImg.transform.localPosition.y) {
				heroImg.transform.Translate (0, speed, 0);
			} else if (y < heroImg.transform.localPosition.y) {
				heroImg.transform.Translate (0, -speed, 0);
			}
		}
	}

	/**
	 * 주인공 애니메이션 속도 변경
	 * speed : 애니메이션 속도
	 * */
	public void changeAnimationSpeed(float speed) {
		heroAnimationSpeed = speed;
	}
}
