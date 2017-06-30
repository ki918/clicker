using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
		DataController.getInstance ().loadUpgradeButton (this);
		UpdateUI ();
	}

	public void purchaseUpgrade() {
		if (DataController.getInstance ().getGold () >= currentCost) {
			DataController.getInstance ().subGold (currentCost);
			level++;
			DataController.getInstance ().addGoldPerClick (goldByUpgrade);

			UpdateUpgrade ();
		}
	}

	public void UpdateUpgrade() {
		goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow (upgradePow, level);
		currentCost = startCurrentCost * (int)Mathf.Pow (costPow, level);
		UpdateUI ();
		DataController.getInstance ().saveUpgradeButton (this);
	}

	public void UpdateUI() {
		upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + level + "\nNext New GoldPerClick: " + goldByUpgrade;
	}
}
