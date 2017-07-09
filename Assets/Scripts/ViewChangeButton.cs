using UnityEngine;
using System.Collections;

public class ViewChangeButton : MonoBehaviour {
	public void viewChange() {
		string name = this.tag;

		UIManager.getInstance ().changeBottomView (name);
	}
}
