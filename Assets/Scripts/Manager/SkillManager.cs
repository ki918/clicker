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
	public float Drop;
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
	//드랍확률증가
	public void ItemChanceUp()
	{
		logCoroutine = ItemChance ();

		StartCoroutine (logCoroutine);
	}

	//터치 골드량 두배
	public void TouchGoldDouble()
	{
		logCoroutine = TouchGold ();

		StartCoroutine (logCoroutine);
	}

	//초당 골드량 두배
	public void AutoGoldDouble()
	{
		logCoroutine = AutoGold ();
		StartCoroutine (logCoroutine);
	}

	void Start () {
		
	}

	//자동터치
	private IEnumerator DisplayLog()
	{
		WaitForSeconds waitSec = new WaitForSeconds (0.033f);

		while (true) {
			DataController.getInstance().TouchScreen(new Vector3());
			yield return waitSec;
		}
	}	

	//터치 골드량 증가
	private IEnumerator TouchGold()
	{
		DataController.getInstance().x = 2;
		yield return new WaitForSeconds (3.0f);
		DataController.getInstance().x = 1;
	}	

	//초당 골드량 증가
	private IEnumerator AutoGold()
	{
		DataController.getInstance().y = 2;
		yield return new WaitForSeconds (3.0f);
		DataController.getInstance().y = 1;
	}	

	//코루틴 중단
	private IEnumerator StopDisplayLog()
	{
		yield return new WaitForSeconds (3.0f);
		//WaitForSeconds초뒤 코틴 중단
		StopCoroutine (logCoroutine);
	}

	//드랍확률 증가
	private IEnumerator ItemChance()
	{
		Drop = DataController.getInstance ().mItemDropChance;
		DataController.getInstance ().z = 1.1f;
		DataController.getInstance ().mItemDropChance = DataController.getInstance ().mItemDropChance * DataController.getInstance ().z;
		yield return new WaitForSeconds (3.0f);
		DataController.getInstance ().mItemDropChance = Drop;
	}	

	//쿨타임
	private IEnumerator timer() {
		int time = (int)3.0f;
		while((time--) >= 0) {
			yield return new WaitForSeconds (1.0f);
		}
	}
}