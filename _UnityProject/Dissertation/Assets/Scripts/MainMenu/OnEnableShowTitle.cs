using UnityEngine;

public class OnEnableShowTitle : MonoBehaviour {


	[SerializeField] GameObject title;

	void OnEnable()
	{
			title.gameObject.SetActive(true);
	}
}
