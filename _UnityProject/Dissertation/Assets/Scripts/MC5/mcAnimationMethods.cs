using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcAnimationMethods : MonoBehaviour {

//    private Animator anim;
    private Collider mcWeapon;
    [SerializeField] GameObject raycast;
    AudioSource[] _sound;

    [SerializeField] private mcMovementBehaviour _mc;
    [SerializeField] GameObject trail;
    [SerializeField] ParticleSystem[] part;


    void Awake()
    {
        _sound = GameObject.FindGameObjectWithTag("mcWeapon").GetComponents<AudioSource>();
    }

    void StepForward()
    {
        _mc.GetComponent<Rigidbody>().AddForce(transform.forward * 40000f);
    }


    // void DecrementAttackQueue()
    // {
    //     if (_mc.attackQueue > 0)
    //         _mc.attackQueue--;
    // }

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
        _mc.isInvincible = false;
    }

    void ActivateWeaponCollider(int a)
    {
        mcWeapon = GameObject.FindGameObjectWithTag("mcWeapon").GetComponent<BoxCollider>();

        if (a == 1)
        {
            mcWeapon.enabled = true;
            raycast.gameObject.SetActive(true);
        }
        else if (a == 0)
        {
            mcWeapon.enabled = false;
            raycast.gameObject.SetActive(false);
            trail.gameObject.SetActive(false);
        }
    }

    void SoundEffect()
    {
        var rand = Random.Range(0,_sound.Length);
        _sound[0].Play();
//        Debug.Log(rand);
    }

    public void PlaySlashParticleSystem(int a)
    {
        part[a].Play();
    }

    public void ActivateTrail(int a)
    {
        if(a == 1)
            trail.gameObject.SetActive(true);
        else
            trail.gameObject.SetActive(false);
    }
}
