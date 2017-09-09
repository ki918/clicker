using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour {
	public Image button; 
	public static Intro intro;
	int count = 1;

	public static Intro getInstance ()
	{
		if (intro == null) {
			intro = FindObjectOfType<Intro> ();

			if (intro == null) {
				GameObject container = new GameObject ("Intro");

				intro = container.AddComponent<Intro> ();
			}
		} 	
		return intro;
	}

	void Start () {
		Screen.SetResolution (Screen.width, Screen.width * 16 / 10, true);
		count = DataController.getInstance ().loadCount ();
	}

	void Update () {

	}

	public void TouchScreen (Vector3 pos)
	{
		if (count == 1) {
			SceneManager.LoadScene (1);
			DataController.getInstance ().saveCount (2);
		} else if (count == 2) {
			SceneManager.LoadScene (2);
		}
	}
}
