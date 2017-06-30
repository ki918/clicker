using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Text goldDisplayer;
	public Text goldPerDisplayer;
	public Text goldPerSecDisplayer;

	void Update() {
		goldDisplayer.text = "GOLD: " + DataController.getInstance ().getGold ();
		goldPerDisplayer.text = "GOLD PER CLICK: " + DataController.getInstance ().getGoldPerClick ();
		goldPerSecDisplayer.text = "GOLD PER SEC: " + DataController.getInstance ().getGoldPerSec ();
	}
}
