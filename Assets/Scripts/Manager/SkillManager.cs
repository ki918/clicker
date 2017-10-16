using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {
	private static SkillManager instance;
	public Image skillFilter;
	public float coolTime;
	public float Gold;
	public float Time;
	IEnumerator logCoroutine = null;

	public static SkillManager getInstance() {
		if (instance == null) {
			instance = FindObjectOfType<SkillManager> ();

			if (instance == null) {
				GameObject container = new GameObject ("SkillManager");

				instance = container.AddComponent<SkillManager> ();
			}
		}

		return instance;
	}
		
	public void AutoTouch()
	{
		//로그 출력 코루틴 실행
		logCoroutine = DisplayLog();
		//로그 출력 중단 코루틴 실행
		StartCoroutine(logCoroutine);
		StartCoroutine(StopDisplayLog());
		StartCoroutine (timer());
	}

	public void TouchGoldDouble()
	{
		logCoroutine = TouchGold ();

		StartCoroutine (logCoroutine);
	}

	void Start () {
		
	}

	private IEnumerator DisplayLog()
	{
		WaitForSeconds waitSec = new WaitForSeconds (0.033f);

		while (true) {
			DataController.getInstance().TouchScreen(new Vector3());
			yield return waitSec;
		}
	}	

	private IEnumerator TouchGold()
	{
		DataController.getInstance().x = 2;
		yield return new WaitForSeconds (3.0f);
		DataController.getInstance().x = 1;
	}	

	private IEnumerator StopDisplayLog()
	{
		yield return new WaitForSeconds (3.0f);
		//WaitForSeconds초뒤 코틴 중단
		StopCoroutine (logCoroutine);
	}

	private IEnumerator timer() {
		int time = (int)3.0f;
		while((time--) >= 0) {
			yield return new WaitForSeconds (1.0f);
		}
	}
}