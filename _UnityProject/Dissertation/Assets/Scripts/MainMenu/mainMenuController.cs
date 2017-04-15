using System.Collections;
using UnityEngine;

public class mainMenuController : MonoBehaviour {

	[SerializeField] GameObject fadeInObject;
	[SerializeField] GameObject pressAnyKey;
	[SerializeField] Animator mcAnim;

	IEnumerator Start()
	{

		yield return new WaitForSeconds(9f);
		mcAnim.SetTrigger("grab");

		yield return new WaitForSeconds(8f);
		pressAnyKey.gameObject.SetActive(true);
	}

	void Update()
	{
		if(Input.anyKeyDown)
		{
			fadeInObject.gameObject.SetActive(true);
		}
	}
}
