using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour {
	public Image button; 

	void Start () {
		//String stage = DataController.getInstance ().getStage ();
		//button.sprite = Resources.Load<Sprite> ("Hero/stage_0" + stage) as Sprite;
	}

	void Update () {
		
	}

	public void Click(){
		SceneManager.LoadScene (2);
	}
}
 