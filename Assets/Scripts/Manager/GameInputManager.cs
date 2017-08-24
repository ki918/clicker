using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameInputManager : MonoBehaviour {
	/**
	 * 터치 이벤트 확인
	 * */
	int count = 1;
	public void Update() {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit ();
			}
		}

		if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.IsPointerOverGameObject (0) == true) {
				return;
			}

			if (EventSystem.current.IsPointerOverGameObject (-1) == true) {
				return;
			}

			if (SceneManager.GetActiveScene ().buildIndex == 1) {
				DataController.getInstance ().TouchScreen (Input.mousePosition);
			}else if (SceneManager.GetActiveScene ().buildIndex == 0) {
				if (count == 1) {
					Opening.getInstance ().TouchScreen (Input.mousePosition);
					count++;
				} else if (count == 2)
				{
					Intro.getInstance ().TouchScreen (Input.mousePosition);
				}
			}else if (SceneManager.GetActiveScene ().buildIndex == 3) {
				Intro.getInstance ().TouchScreen (Input.mousePosition);
			} 
		}
	}
}