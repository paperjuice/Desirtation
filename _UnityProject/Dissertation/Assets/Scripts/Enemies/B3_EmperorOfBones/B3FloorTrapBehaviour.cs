using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3FloorTrapBehaviour : MonoBehaviour {

  [SerializeField] GameObject spikeMesh;
  [SerializeField] float timeUntilSpiked = 1f;
  [SerializeField] float damage = 10f;
  bool isSpiky;

  GameObject player;

  void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    StartCoroutine(SpikeDamage());
  }

  void Start()
  {
    damage += controller.dungeonLevel *1.2f;
  }

  void OnTriggerStay(Collider col)
  {
    if(col.gameObject.tag == "Player")
    {
      player.GetComponent<debuff>().Slow(0.5f);
    }

    if(col.gameObject.tag == "Player" && isSpiky)
    {
      player.GetComponent<mcStats>().IncrementAgeOnDamageReceived(damage);
      Camera.main.GetComponent<Animator>().SetTrigger("shakePlayer");
      isSpiky = false;
    }
  }

  

  IEnumerator SpikeDamage()
  {
    yield return new WaitForSeconds(1f);
    isSpiky = true;
    spikeMesh.transform.localPosition = Vector3.zero;
    yield return new WaitForSeconds(1f);
    Destroy(gameObject);
  }

	

}
