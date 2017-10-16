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
		//< 인스턴스가 null인지 검사
		if (instance == null) {
			//< 인스턴스가 null이라면 화면에서 HeroManager Class를 찾아서 인스턴스에 넣어줌
			instance = FindObjectOfType<HeroManager> (); 
			//< 다시 null 검사
			if (instance == null) { 
				//< 화면에 HeroManager Class가 없어 null인 경우 GameObject를 새로 만들어서 HeroManager를 넣어줌
				GameObject container = new GameObject ("HeroManager"); 
				//< 새로 만든 GameObject를 현재 화면에 추가해줌
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
		//< 아이템 획득
		UIManager.getInstance ().deleteItem ();
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
