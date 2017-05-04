using System.Collections;
using UnityEngine;

public class EndSceneOutsideController : MonoBehaviour {

	[SerializeField] Rigidbody _rigid;
	[SerializeField] Animator anim;
	[SerializeField] fadeOutFadein fade;
	GameObject[] _audio;
	bool isSoundFading = false;

	void Awake()
	{
		_audio = GameObject.FindGameObjectsWithTag("audio");
	}

	IEnumerator Start()
	{
		yield return new WaitForSeconds(3f);
		_rigid.isKinematic = false;
		_rigid.transform.parent = null;
		yield return new WaitForSeconds(1f);
		anim.SetTrigger("up");
		yield return new WaitForSeconds(14.8f);
		isSoundFading = true;
		fade.enabled = true;
	}

	void Update()
	{
		if(isSoundFading)
		{
			foreach(GameObject go in _audio)
			{
				if(go != null)
				{
					go.GetComponent<AudioSource>().volume -= 0.5f * Time.deltaTime; 
					if(go.GetComponent<AudioSource>().volume <= 0)
						Destroy(go.gameObject);
				}
			}
		}
	}
}
