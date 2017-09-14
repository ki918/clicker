using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTextControl : MonoBehaviour {

	public Text readyText;
	public static GameTextControl instanece;

	void Awake()
	{
		if (GameTextControl.instanece == null)
			GameTextControl.instanece = this;
	}
	// Use this for initialization

	void Start ()
	{
		StartCoroutine("ShowReady");
	}

	IEnumerator ShowReady()
	{
		while ( true) 
		{
			readyText.text = "";
			yield return new WaitForSeconds (0.5f);
			readyText.text = "Touch to Screen";
			yield return new WaitForSeconds (0.5f);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
