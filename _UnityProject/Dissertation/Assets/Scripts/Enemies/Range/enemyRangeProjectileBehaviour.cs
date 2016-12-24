using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRangeProjectileBehaviour : MonoBehaviour {


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
                _mcStats.Health(dmg);
                _mcDebuffs.secondsInterrupted = interruptTime; //Interrupt - this will be iterated based on enemy type
                _mcDebuffs.PushBack(new Vector3(transform.position.x, _player.transform.position.y, transform.position.z), _mcDebuffs.transform.position, pushBackForce); //PushBack - iterate force
                gameObject.SetActive(false);
            }
        }
    }


}
