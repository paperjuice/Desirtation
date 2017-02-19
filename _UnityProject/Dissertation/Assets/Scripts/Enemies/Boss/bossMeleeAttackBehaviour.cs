using System.Collections;
using UnityEngine;

public class bossMeleeAttackBehaviour : MonoBehaviour {

    [SerializeField] Animator _anim;
    [SerializeField]
    public int numberOfCombos;


	public IEnumerator MeleeAttack()
	{
		numberOfCombos = Random.Range(1, 6);

        while (numberOfCombos != 0)
        {
            _anim.SetBool("attack", true);
            yield return new WaitForSeconds(0.5f);
        }

        if (numberOfCombos == 0)
        {
            _anim.SetBool("attack", false);
           // _bossGeneralBehaviour.enabled = true;
        }
    }





}
