using UnityEngine;
using System.Collections;

public class DataController : MonoBehaviour {
	private static DataController dataController;
	private int m_Gold = 0;
	private int m_GoldPerClick = 0;
	private ItemButton[] itemButtons;

	public static DataController getInstance() {
		if (dataController == null) {
			dataController = FindObjectOfType<DataController> ();

			if (dataController == null) {
				GameObject container = new GameObject ("DataController");

				dataController = container.AddComponent<DataController> ();
			}
		}

		return dataController;
	}

	void Awake() {
		m_Gold = PlayerPrefs.GetInt ("Gold");
		m_GoldPerClick = PlayerPrefs.GetInt ("GoldPerClick", 1);
		itemButtons = FindObjectsOfType<ItemButton> ();
		Screen.SetResolution (Screen.width, Screen.width * 3 / 2, true);
	}

	public void setGold(int newGold) {
		m_Gold = newGold;
		PlayerPrefs.SetInt ("Gold", m_Gold);
	}

	public void addGold(int newGold) {
		m_Gold += newGold;
		setGold (m_Gold);
	}

	public void subGold(int newGold) {
		m_Gold -= newGold;
		setGold (m_Gold);
	}

	public int getGold() {
		return m_Gold;
	}

	public int getGoldPerClick() {
		return m_GoldPerClick;
	}

	public void setGoldPerClick(int newGoldPerClick) {
		m_GoldPerClick = newGoldPerClick;
		PlayerPrefs.SetInt ("GoldPerClick", m_GoldPerClick);
	}

	public void addGoldPerClick(int newGoldPerClick) {
		m_GoldPerClick += newGoldPerClick;
		PlayerPrefs.SetInt ("GoldPerClick", m_GoldPerClick);
	}

	public void loadUpgradeButton(UpgradeButton upgradeButton) {
		string key = upgradeButton.upgradeName;

		upgradeButton.level = PlayerPrefs.GetInt (key + "_level", 1);
		upgradeButton.goldByUpgrade = PlayerPrefs.GetInt (key + "_GoldByUpgrade", upgradeButton.startGoldByUpgrade);
		upgradeButton.currentCost = PlayerPrefs.GetInt (key + "_cost", upgradeButton.startCurrentCost);
	}

	public void saveUpgradeButton(UpgradeButton upgradeButton) {
		string key = upgradeButton.upgradeName;

		PlayerPrefs.SetInt (key + "_level", upgradeButton.level);
		PlayerPrefs.SetInt (key + "_GoldByUpgrade", upgradeButton.goldByUpgrade);
		PlayerPrefs.SetInt (key + "_cost", upgradeButton.currentCost);
	}

	public void loadItemButton(ItemButton itemButton) {
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

	public void saveItemButton(ItemButton itemButton) {
		string key = itemButton.itemName;

		PlayerPrefs.SetInt (key + "_level", itemButton.level);
		PlayerPrefs.SetInt (key + "_GoldBySec", itemButton.startGoldPerSec);
		PlayerPrefs.SetInt (key + "_cost", itemButton.currentCost);

		if (itemButton.isPurchase) {
			PlayerPrefs.SetInt (key + "_purchase", 1);
		} else {
			PlayerPrefs.SetInt (key + "_purchase", 0);
		}
	}

	public int getGoldPerSec() {
		int result = 0;

		for (int i = 0; i < itemButtons.Length; i++) {
			result += itemButtons [i].goldPerSec;
		}

		return result;
	}

	public void TouchScreen(Vector3 pos) {
		int gold = getGoldPerClick ();
		addGold (gold);
	}
}
