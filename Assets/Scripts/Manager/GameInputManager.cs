using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameInputManager : MonoBehaviour {
	/**
	 * 터치 이벤트 확인
	 * */

	private const int INTRO_SCENE = 0;
	private const int OPENING_SCENE = 1;
	private const int MAIN_SCENE = 2;
	private const int TITLE_SCENE = 3;

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

			if (SceneManager.GetActiveScene ().buildIndex == MAIN_SCENE) {
				DataController.getInstance ().TouchScreen (Input.mousePosition);
			} else if (SceneManager.GetActiveScene ().buildIndex == OPENING_SCENE) {
				Opening.getInstance ().TouchScreen (Input.mousePosition);
			} else if (SceneManager.GetActiveScene ().buildIndex == INTRO_SCENE) {
				Intro.getInstance ().TouchScreen (Input.mousePosition);
			} else if (SceneManager.GetActiveScene ().buildIndex == TITLE_SCENE) {
				Title.getInstance ().TouchScreen (Input.mousePosition);
			}
		}
	}
}