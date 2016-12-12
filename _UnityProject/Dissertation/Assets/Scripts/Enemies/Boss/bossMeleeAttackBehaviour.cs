using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMeleeAttackBehaviour : MonoBehaviour {

    [SerializeField] Animator _anim;
    bossGeneralBehaviour _bossGeneralBehaviour;
    [SerializeField]
    public int numberOfCombos;

    void Awake()
    {
        _bossGeneralBehaviour = GetComponent<bossGeneralBehaviour>();
    }

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
