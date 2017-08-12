using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeButton : MonoBehaviour {
	public Text upgradeDisplayer;

	public string upgradeName;

	[HideInInspector]
	public int goldByUpgrade;
	public int startGoldByUpgrade;

	[HideInInspector]
	public int currentCost = 1;
	public int startCurrentCost = 1;

	[HideInInspector]
	public int level = 1;

	public float upgradePow = 1.07f;
	public float costPow = 3.14f;



	void Start() {
		// 게임 시작시 버튼들의 저장 값을 가져온다
		DataController.getInstance ().loadUpgradeButton (this);
		UpdateUI ();
		//PlayerPrefs.DeleteAll ();

	}

	/**
	 * 버튼 클릭 이벤트
	 * 업그레이드 실행
	 * */
	public void purchaseUpgrade() {

		Restoration();

		if (DataController.getInstance ().getGold () >= currentCost) {
			DataController.getInstance ().subGold (currentCost);
			level++;
			DataController.getInstance ().addGoldPerClick (goldByUpgrade);

			UpdateUpgrade ();
		}
	}

	/**
	 * 업그레이드 상태 반영
	 * */
	public void UpdateUpgrade() {
		goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow (upgradePow, level);
		currentCost = startCurrentCost * (int)Mathf.Pow (costPow, level);
		UpdateUI ();
		// 변경 된 버튼의 정보 저장
		DataController.getInstance ().saveUpgradeButton (this);

	}

	/**
	 * 화면에 보여질 정보 업데이트
	 * */
	public void UpdateUI() {
		upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + level + "\nNext New GoldPerClick: " + goldByUpgrade;
	}
		

	public void Restoration() {

		if (this.gameObject.tag.Equals ("Restoration") && level < 20) {
			UpdateUpgrade ();
		} else if (this.gameObject.tag.Equals("Restoration") && level == 20) {
			//씬 전환
			this.level = 0;
			DataController.getInstance().ReturnToTitle();
		}
	}
}
