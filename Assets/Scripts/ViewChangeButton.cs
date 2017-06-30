using UnityEngine;
using System.Collections;

public class ViewChangeButton : MonoBehaviour {
	public void viewChange() {
		string name = this.tag;

		name = name.Replace ("Button", "Panel");
		UIManager.getInstance ().changeBottomView (name);
	}
}
