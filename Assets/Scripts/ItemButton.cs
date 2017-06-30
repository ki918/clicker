using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {
	public Text itemDisplayer;

	public string itemName;

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
		DataController.getInstance ().loadItemButton (this);
		StartCoroutine ("addGoldLoop");
		updateUI ();
	}

	public void purchaseItem() {
		if (DataController.getInstance ().getGold () >= currentCost) {
			isPurchase = true;
			DataController.getInstance ().subGold (currentCost);
			level++;

			updateItem ();
		}
	}

	IEnumerator addGoldLoop() {
		while (true) {
			if (isPurchase) {
				DataController.getInstance ().addGold (goldPerSec);
			}

			yield return new WaitForSeconds (1.0f);
		}
	}

	public void updateItem() {
		goldPerSec += startGoldPerSec * (int)Mathf.Pow (upgradePow, level);
		currentCost = startCurrentCost * (int)Mathf.Pow (costPow, level);
		DataController.getInstance ().saveItemButton (this);
		updateUI ();
	}

	public void updateUI() {
		itemDisplayer.text = itemName + "\nLevel: " + level + "\nCost: " + currentCost + "\nGold Per Second: " + goldPerSec + "\nIsPurchase: " + isPurchase;
	}
}
