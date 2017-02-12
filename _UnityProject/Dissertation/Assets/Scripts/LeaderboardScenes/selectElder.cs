using UnityEngine;

public class selectElder : MonoBehaviour {

	[SerializeField] SkinnedMeshRenderer glow;
	[SerializeField] GameObject _img;
	[SerializeField] fadeOutFadein _fd;

	void OnMouseEnter()
	{
		glow.enabled = true;
		_img.gameObject.SetActive(true);
	}
	
	void OnMouseExit()
	{
		glow.enabled = false;
		_img.gameObject.SetActive(false);
	}

	void OnMouseUpAsButton()
	{
		_fd.enabled = true;
	}




}
