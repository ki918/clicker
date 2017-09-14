using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
	private static DataController dataController;
	private int m_Gold = 0;
	private int m_GoldPerClick = 0;
	private ItemButton[] itemButtons;
	private GameObject viewItem;
	private int mCurrentStage;

	public GameObject firstItem;
	public GameObject itemZone;
	public float mItemDropChance;

	/**
	 * 싱글톤 생성
	 * */
	public static DataController getInstance ()
	{
		if (dataController == null) {
			dataController = FindObjectOfType<DataController> ();

			if (dataController == null) {
				GameObject container = new GameObject ("DataController");

				dataController = container.AddComponent<DataController> ();
			}
		}

		return dataController;
	}

	void Awake ()
	{
		//m_Gold = PlayerPrefs.GetInt ("Gold");
		m_Gold = 10000000;
		m_GoldPerClick = PlayerPrefs.GetInt ("GoldPerClick", 1);
		loadStage ();
		itemButtons = FindObjectsOfType<ItemButton> ();
		Screen.SetResolution (Screen.width, Screen.width * 16 / 10, true);
	}

	void Start ()
	{
		// addGoldPerSecLoop 함수 루프 시작
		StartCoroutine ("addGoldPerSecLoop");
	}
		
	/**
	 * 골드 저장용
	 * newGold : 저장 할 골드
	 * */
	public void setGold (int newGold)
	{
		m_Gold = newGold;
		PlayerPrefs.SetInt ("Gold", m_Gold);
	}

	/**
	 * 골드 증가
	 * newGold : 증가량
	 * */
	public void addGold (int newGold)
	{
		m_Gold += newGold;
		setGold (m_Gold);
	}

	/**
	 * 골드 감소
	 * newGold : 감소량
	 * */
	public void subGold (int newGold)
	{
		m_Gold -= newGold;
		setGold (m_Gold);
	}

	/**
	 * 현재 골드량
	 * return int 현재 골드
	 * */
	public int getGold ()
	{
		return m_Gold;
	}

	/**
	 * 터치 당 증가 골드량
	 * return int 증가 골드량
	 * */
	public int getGoldPerClick ()
	{
		return m_GoldPerClick;
	}

	/**
	 * 터치 당 골드 증가
	 * newGoldPerClick : 터치 당 증가량
	 * */
	public void setGoldPerClick (int newGoldPerClick)
	{
		m_GoldPerClick = newGoldPerClick;
		PlayerPrefs.SetInt ("GoldPerClick", m_GoldPerClick);
	}

	public void addGoldPerClick (int newGoldPerClick)
	{
		m_GoldPerClick += newGoldPerClick;
		PlayerPrefs.SetInt ("GoldPerClick", m_GoldPerClick);
	}

	public void loadUpgradeButton (UpgradeButton upgradeButton)
	{
		string key = upgradeButton.upgradeName;

		upgradeButton.level = PlayerPrefs.GetInt (key + "_level", 1);
		upgradeButton.goldByUpgrade = PlayerPrefs.GetInt (key + "_GoldByUpgrade", upgradeButton.startGoldByUpgrade);
		upgradeButton.currentCost = PlayerPrefs.GetInt (key + "_cost", upgradeButton.startCurrentCost);
	}

	public void saveUpgradeButton (UpgradeButton upgradeButton)
	{
		string key = upgradeButton.upgradeName;

		PlayerPrefs.SetInt (key + "_level", upgradeButton.level);
		PlayerPrefs.SetInt (key + "_GoldByUpgrade", upgradeButton.goldByUpgrade);
		PlayerPrefs.SetInt (key + "_cost", upgradeButton.currentCost);
	}

	public void loadItemButton (ItemButton itemButton)
	{
		string key = itemButton.itemName;

		itemButton.level = PlayerPrefs.GetInt (key + "_level", 0);
		itemButton.goldPerSec = PlayerPrefs.GetInt (key + "_GoldBySec", itemButton.startGoldPerSec);
		itemButton.currentCost = PlayerPrefs.GetInt (key + "_cost", itemButton.startCurrentCost);

		if (PlayerPrefs.GetInt (key + "_purchase") == 1) {
			itemButton.isPurchase = true;
		} else {
			itemButton.isPurchase = false;
		}
	}

	public void saveItemButton (ItemButton itemButton)
	{
		string key = itemButton.itemName;

		PlayerPrefs.SetInt (key + "_level", itemButton.level);
		PlayerPrefs.SetInt (key + "_GoldBySec", itemButton.goldPerSec);
		PlayerPrefs.SetInt (key + "_cost", itemButton.currentCost);

		if (itemButton.isPurchase) {
			PlayerPrefs.SetInt (key + "_purchase", 1);
		} else {
			PlayerPrefs.SetInt (key + "_purchase", 0);
		}
	}

	public void loadSkillButton (SkillButton skillButton)
	{
		string key = skillButton.SkillName;

		skillButton.level = PlayerPrefs.GetInt (key + "_level", 0);
		skillButton.goldPerSec = PlayerPrefs.GetInt (key + "_GoldBySec", skillButton.startGoldPerSec);
		skillButton.currentCost = PlayerPrefs.GetInt (key + "_cost", skillButton.startCurrentCost);

		if (PlayerPrefs.GetInt (key + "_purchase") == 1) {
			skillButton.isPurchase = true;
		} else {
			skillButton.isPurchase = false;
		}
	}

	public void saveSkillButton (SkillButton skillButton)
	{
		string key = skillButton.SkillName;

		PlayerPrefs.SetInt (key + "_level", skillButton.level);
		PlayerPrefs.SetInt (key + "_GoldBySec", skillButton.goldPerSec);
		PlayerPrefs.SetInt (key + "_cost", skillButton.currentCost);

		if (skillButton.isPurchase) {
			PlayerPrefs.SetInt (key + "_purchase", 1);
		} else {
			PlayerPrefs.SetInt (key + "_purchase", 0);
		}
	}


	public void loadCashButton (CashButton cashButton)
	{
		string key = cashButton.cashName;

		cashButton.level = PlayerPrefs.GetInt (key + "_level", 0);
		cashButton.goldPerSec = PlayerPrefs.GetInt (key + "_GoldBySec", cashButton.startGoldPerSec);
		cashButton.currentCost = PlayerPrefs.GetInt (key + "_cost", cashButton.startCurrentCost);

		if (PlayerPrefs.GetInt (key + "_purchase") == 1) {
			cashButton.isPurchase = true;
		} else {
			cashButton.isPurchase = false;
		}
	}

	public void saveCashButton (CashButton cashButton)
	{
		string key = cashButton.cashName;

		PlayerPrefs.SetInt (key + "_level", cashButton.level);
		PlayerPrefs.SetInt (key + "_GoldBySec", cashButton.goldPerSec);
		PlayerPrefs.SetInt (key + "_cost", cashButton.currentCost);

		if (cashButton.isPurchase) {
			PlayerPrefs.SetInt (key + "_purchase", 1);
		} else {
			PlayerPrefs.SetInt (key + "_purchase", 0);
		}
	}


	/**
	* 현재 스테이지 저장
	* */
	public void saveCount(int count) {
		string key = "count";

		PlayerPrefs.SetInt (key, count);
	}

	public int loadCount() {
		return PlayerPrefs.GetInt ("count", 1);
	}


	/*
	 * 현재 스테이지 저장
	 * */
	public void saveStage(int stage) {
		string key = "STAGE_NUMBER";

		PlayerPrefs.SetInt (key, stage);
	}

	/*
	 * 현재 스테이지 불러오기
	 * */	
	public void loadStage() {
		mCurrentStage = PlayerPrefs.GetInt ("STAGE_NUMBER", 1);
	}

	/**
	 * 스테이지 정보 반환
	 * */
	public int getStage() {
		return mCurrentStage;
	}

	/**
	 * 스테이지 정보 저장
	 * */
	public void setStage(int stage) {
		mCurrentStage = stage;
		saveStage (stage);
	}
		
	public int getGoldPerSec ()
	{
		int result = 0;

		for (int i = 0; i < itemButtons.Length; i++) {
			if (itemButtons [i].isPurchase) {
				result += itemButtons [i].goldPerSec;
			}
		}

		return result;
	}


	/**
	 * 터치 이벤트 처리
	 * pos : 터치 좌표
	 * */
	public void TouchScreen (Vector3 pos)
	{
		int gold = getGoldPerClick ();
		//< 아이템 랜덤 생성
		int rand = Random.Range (1, 10001);
		Debug.Log ("드랍 확률 : " + rand);
		if ((mItemDropChance) >= rand) {
			dropItem ();
		}
		addGold (gold);

		AudioManager.getInstance ().playSFX (0);
	}

	/**
	 * 아이템 생성
	 * */
	private void dropItem ()
	{
		if (viewItem == null) {
			//< 프리팹 생성
			viewItem = (GameObject)Instantiate (firstItem, new Vector3 (1.0f, 1.0f, 0.0f), Quaternion.identity);
			viewItem.transform.SetParent (itemZone.transform);
			viewItem.transform.localScale = Vector3.one;
			float rand = Random.Range (-100.0f, 100.0f);
			viewItem.transform.localPosition = new Vector3 (1.0f, rand, 0.0f);

			UIManager.getInstance ().setItem (viewItem);
		}
	}

	IEnumerator addGoldPerSecLoop ()
	{
		while (true) {
			addGold (getGoldPerSec ());

			yield return new WaitForSeconds (1.0f);
		}
	}

	public void ReturnToTitle ()
	{
		SceneManager.LoadScene ("Title");
	}
}
