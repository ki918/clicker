using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour {
	public Image button; 

	//Use this for initialization
	void Start () {
		//String stage = DataController.getInstance ().getStage ();
		//button.sprite = Resources.Load<Sprite> ("Hero/stage_0" + stage) as Sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Click(){
		SceneManager.LoadScene (2);
	}
}
 