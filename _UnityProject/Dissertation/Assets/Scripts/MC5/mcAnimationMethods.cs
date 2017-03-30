using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcAnimationMethods : MonoBehaviour {

//    private Animator anim;
    private Collider mcWeapon;
    AudioSource[] _sound;

    [SerializeField] private mcMovementBehaviour _mc;


    void Awake()
    {
        _sound = GameObject.FindGameObjectWithTag("mcWeapon").GetComponents<AudioSource>();
    }

    void StepForward()
    {
        _mc.GetComponent<Rigidbody>().AddForce(transform.forward * 40000f);
    }


    void DecrementAttackQueue()
    {
        if (_mc.attackQueue > 0)
            _mc.attackQueue--;
    }

    void SetInvincibility(int a)
    {
        if (a == 0)
            _mc.isInvincible = false;
        else if (a == 1)
            _mc.isInvincible = true;
    }

    void DisableRolling()
    {
        _mc.isRolling = false;
    }

    void ActivateWeaponCollider(int a)
    {
        mcWeapon = GameObject.FindGameObjectWithTag("mcWeapon").GetComponent<BoxCollider>();

        if (a == 1)
            mcWeapon.enabled = true;
        else if (a == 0)
            mcWeapon.enabled = false;
    }

    void SoundEffect()
    {
        var rand = Random.Range(0,_sound.Length);
        _sound[0].Play();
        Debug.Log(rand);
    }

}
