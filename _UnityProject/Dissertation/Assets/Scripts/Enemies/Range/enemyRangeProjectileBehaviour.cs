using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRangeProjectileBehaviour : MonoBehaviour {

    [SerializeField] ParticleSystem collisionParticleEffect;
    [SerializeField] float ms;
    [SerializeField] float dmg;
    [SerializeField] float pushBackForce;
    [SerializeField] float interruptTime;


    private mcMovementBehaviour _player;
    private mcStats _mcStats;
    private debuff _mcDebuffs;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<mcMovementBehaviour>();
        _mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
        _mcDebuffs = GameObject.FindGameObjectWithTag("Player").GetComponent<debuff>();
    }

    private void Update()
    {
        transform.position += Time.deltaTime * ms * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!_player.isInvincible)
            {
                Camera.main.GetComponent<Animator>().SetTrigger("shake");
                _mcStats.IncrementAgeOnDamageReceived(dmg);
                _mcDebuffs.SecondsInterrupted = interruptTime; //Interrupt - this will be iterated based on enemy type
                _mcDebuffs.PushBack(new Vector3(transform.position.x, _player.transform.position.y, transform.position.z), _mcDebuffs.transform.position, pushBackForce); //PushBack - iterate force
                gameObject.SetActive(false);
                collisionParticleEffect.transform.parent = null;
                collisionParticleEffect.transform.position = gameObject.transform.position;
                collisionParticleEffect.Play();
            }
        }

        if (other.gameObject.tag == "prop")
        {
            gameObject.SetActive(false);
            collisionParticleEffect.transform.parent = null;
            collisionParticleEffect.transform.position = gameObject.transform.position;
            collisionParticleEffect.Play();
        }
    }


}
