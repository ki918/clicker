using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening : MonoBehaviour {
	public Image button; 
	public static Opening opening;
	public static Opening getInstance ()
	{
		if (opening == null) {
			opening = FindObjectOfType<Opening> ();

			if (opening == null) {
				GameObject container = new GameObject ("Opening");

				opening = container.AddComponent<Opening> ();
			}
		} 	
		return opening;
	}

	void Start () {
		Screen.SetResolution (Screen.width, Screen.width * 16 / 10, true);
	}

	void Update () {

	}

	public void TouchScreen (Vector3 pos)
	{
		SceneManager.LoadScene (2);
	}
}
