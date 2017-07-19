using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private static UIManager uiManager;

	public Text goldDisplayer;
	public Text goldPerDisplayer;
	public Text goldPerSecDisplayer;
	public GameObject settingPanel;
	public Material background;
	public int moveSpeed;

	private ArrayList panelList;
	private GameObject moveItemObject;

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

		Vector2 vec = background.mainTextureOffset;
		vec.Set (vec.x + (moveSpeed * Time.deltaTime), 0);
		background.mainTextureOffset = vec;

		if (moveItemObject != null) {
			//< 아이템 이동
			moveItemObject.transform.Translate (Vector3.left * (moveSpeed * 280) * Time.deltaTime);

			//< 아이템 화면 밖으로 나가는 경우
			Vector3 itemVec = Camera.main.WorldToViewportPoint(moveItemObject.transform.position);

			if (itemVec.x < 0) {
				Destroy (moveItemObject);
			}
		}
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

	public void setItem(GameObject item) {
		moveItemObject = item;
	}
}
