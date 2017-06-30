using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {
	public void onClick() {
		int goldPerClick = DataController.getInstance ().getGoldPerClick ();
		DataController.getInstance ().addGold (goldPerClick);
	}
}
