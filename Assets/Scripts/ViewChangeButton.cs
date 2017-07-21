using UnityEngine;
using System.Collections;

public class ViewChangeButton : MonoBehaviour {
	/**
	 * 하단 스크롤뷰 화면 전환 버튼
	 * */
	public void viewChange() {
		string name = this.tag;

		name = name.Replace ("Button", "Panel");
		UIManager.getInstance ().changeBottomView (name);
	}
}
