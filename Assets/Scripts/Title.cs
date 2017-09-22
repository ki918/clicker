using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour {
	public Image button; 
	public static Title title;
	public int round = 1;
	public Text myText;
	public static Title getInstance ()
	{
		if (title == null) {
			title = FindObjectOfType<Title> ();

			if (title == null) {
				GameObject container = new GameObject ("Title");

				title = container.AddComponent<Title> ();
			}
		} 	
		return title;
	}

	void Start () {
		//gameObject.tag.Equals ("stage").ToString = round;
		//String stage = DataController.getInstance ().getStage ();
		//button.sprite = Resources.Load<Sprite> ("Hero/stage_0" + stage) as Sprite;
		Screen.SetResolution (Screen.width, Screen.width * 16 / 10, true);

	}

	void Update () {
		
	}

	public void TouchScreen (Vector3 pos)
	{
		SceneManager.LoadScene (2);
	}

}
 