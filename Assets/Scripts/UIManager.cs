using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private static UIManager uiManager;

	public Text goldDisplayer;
	public Text goldPerDisplayer;
	public Text goldPerSecDisplayer;
	public GameObject settingPanel;

	private ArrayList panelList;

	public static UIManager getInstance() {
		if (uiManager == null) {
			uiManager = FindObjectOfType<UIManager> ();

			if (uiManager == null) {
				GameObject container = new GameObject ("UIManager");

				uiManager = container.AddComponent<UIManager> ();
			}
		}

		return uiManager;
	}

	void Start() {
		panelList = new ArrayList ();
		panelList.Add (GameObject.FindWithTag ("UpgradePanel"));
		panelList.Add (GameObject.FindWithTag ("ItemPanel"));

		for (int i = 1; i < panelList.Count; i++) {
			GameObject obj = (GameObject)panelList [i];

			obj.SetActive (false);
		}
	}

	void Update() {
		goldDisplayer.text = "GOLD: " + DataController.getInstance ().getGold ();
		goldPerDisplayer.text = "GOLD PER CLICK: " + DataController.getInstance ().getGoldPerClick ();
		goldPerSecDisplayer.text = "GOLD PER SEC: " + DataController.getInstance ().getGoldPerSec ();
	}

	public void changeBottomView(string tag) {
		for (int i = 0; i < panelList.Count; i++) {
			GameObject obj = (GameObject)panelList [i];

			if (obj.tag.Equals (tag)) {
				obj.SetActive (true);
			} else {
				obj.SetActive (false);
			}
		}
	}

	public void ShowSettingPanel() {
		settingPanel.SetActive (true);
	}

	public void HideSettingPanel() {
		settingPanel.SetActive (false);
	}
}
