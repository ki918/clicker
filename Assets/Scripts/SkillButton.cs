using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {
	public Text SkillDisplayer;

	public string SkillName;

	public int level;
	[HideInInspector]
	public int currentCost;
	public int startCurrentCost = 1;
	[HideInInspector]
	public int goldPerSec;
	public int startGoldPerSec = 1;

	public float costPow = 3.14f;
	public float upgradePow = 1.07f;
	[HideInInspector]
	public bool isPurchase = false;

	void Start() {
		// 게임 시작시 버튼들의 상태값을 가져온다
		DataController.getInstance ().loadSkillButton (this);
		// addGoldLoop 함수 시작
		StartCoroutine ("addGoldLoop");
		updateUI ();
	}

	/**
	 * 버튼 클릭 이벤트
	 * 업그레이드 실행
	 * */
	public void purchaseSkill() {
		if (DataController.getInstance ().getGold () >= currentCost) {
			isPurchase = true;
			DataController.getInstance ().subGold (currentCost);
			level++;

			updateSkill ();
		}
	}

	/**
	 * 자동 획득 골드 루틴
	 * */
	IEnumerator addGoldLoop() {
		while (true) {
			if (isPurchase) {
				DataController.getInstance ().addGold (goldPerSec);
			}

			yield return new WaitForSeconds (1.0f);
		}
	}

	/**
	 * 업그레이드 상태 반영
	 * */
	public void updateSkill() {
		goldPerSec += startGoldPerSec * (int)Mathf.Pow (upgradePow, level);
		currentCost = startCurrentCost * (int)Mathf.Pow (costPow, level);
		DataController.getInstance ().saveSkillButton (this);
		updateUI ();
	}

	/**
	 * 화면에 보여질 정보 업데이트
	 * */
	public void updateUI() {
		SkillDisplayer.text = SkillName + "\nLevel: " + level + "\nCost: " + currentCost + "\nGold Per Second: " + goldPerSec + "\nIsPurchase: " + isPurchase;
	}
}
