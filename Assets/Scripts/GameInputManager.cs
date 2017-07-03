using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GameInputManager : MonoBehaviour {
	public void Update() {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit ();
			}
		}

		if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.IsPointerOverGameObject () == false) {
				DataController.getInstance ().TouchScreen (Input.mousePosition);
			}
		}
	}
}
