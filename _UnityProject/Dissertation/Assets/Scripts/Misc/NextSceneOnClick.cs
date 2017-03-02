using UnityEngine;


public class NextSceneOnClick : MonoBehaviour {


	[SerializeField] fadeOutFadein _fade;

	public void ChangeSceneOnClick()
	{
		_fade.enabled = true;
	}
}
