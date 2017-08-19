using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour {
	public Image button; 
	public static Intro intro;

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
	}

	void Update () {

	}

	public void TouchScreen (Vector3 pos)
	{
		SceneManager.LoadScene (1);
	}
}
