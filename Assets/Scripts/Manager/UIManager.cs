using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private static UIManager uiManager;

	public Text goldDisplayer;
	public Text goldPerDisplayer;
	public Text goldPerSecDisplayer;
	public Text stageDisplayer;
	public GameObject settingPanel;
	public Material background;
	public float moveSpeed;
	public float heroSpeed;

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
		panelList.Add (GameObject.FindWithTag ("CashPanel"));
		AudioManager.getInstance ().playGameBGM ();


		for (int i = 1; i < panelList.Count; i++) {
			GameObject obj = (GameObject)panelList [i];

			obj.SetActive (false);
		}

		stageDisplayer.text = DataController.getInstance ().getStage () + "Stage";
	}

	void Update() {
		HeroManager.getInstance ().changeAnimationSpeed (heroSpeed / moveSpeed);
		goldDisplayer.text = DataController.getInstance ().getGold () + "G";
		goldPerDisplayer.text = DataController.getInstance ().getGoldPerClick () + "G/클릭";
		goldPerSecDisplayer.text = DataController.getInstance ().getGoldPerSec () + "G/초";

		Vector2 vec = background.mainTextureOffset;
		vec.Set (vec.x + (moveSpeed * Time.deltaTime), 0);
		background.mainTextureOffset = vec;

		if (moveItemObject != null) {
			//< 아이템 이동
			moveItemObject.transform.Translate (Vector3.left * (moveSpeed * 280) * Time.deltaTime);
			HeroManager.getInstance ().moveToItem (moveSpeed, moveItemObject);

			//< 아이템 화면 밖으로 나가는 경우
			Vector3 itemVec = Camera.main.WorldToViewportPoint(moveItemObject.transform.position);

			if (itemVec.x < 0) {
				Destroy (moveItemObject);
			}
		}
	}

	/**
	 * 하단 버튼 선택에 따라 리스트 변경
	 * */
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

	/**
	 * 환경설정 UI Show
	 * */
	public void ShowSettingPanel() {
		settingPanel.SetActive (true);
	}

	/**
	 * 환경설정 UI hide
	 * */
	public void HideSettingPanel() {
		settingPanel.SetActive (false);
	}

	/**
	 * 아이템 오브젝트 저장
	 * */
	public void setItem(GameObject item) {
		moveItemObject = item;
	}

	/**
	 * 아이템 오브젝트 삭제
	 * */
	public void deleteItem() {
		if (moveItemObject != null) {
			Destroy (moveItemObject);
		}
	}
}
