using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneOutsideController : MonoBehaviour {

	[SerializeField] Rigidbody _rigid;
	[SerializeField] Animator anim;
	[SerializeField] fadeOutFadein fade;

	IEnumerator Start()
	{
		yield return new WaitForSeconds(3f);
		_rigid.isKinematic = false;
		_rigid.transform.parent = null;
		yield return new WaitForSeconds(1f);
		anim.SetTrigger("up");
		yield return new WaitForSeconds(10f);
		fade.enabled = true;
	}
}
