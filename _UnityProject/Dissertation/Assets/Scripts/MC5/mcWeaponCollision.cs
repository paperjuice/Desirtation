using UnityEngine;

public class mcWeaponCollision : MonoBehaviour {

    private Animator _mainCamera;
    private mcStats _mcStats;

    private float weaponDamage = 3;
    public float WeaponDamage
    {
        get { return weaponDamage; }
        set { weaponDamage = value; }
    }



    void Awake()
    {
        _mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            _mcStats.Knowledge(0.1f+controller.dungeonLevel);  //this needs iteration
            _mainCamera.SetTrigger("shake");
            col.gameObject.GetComponent<generalEnemyStats>().eCurrentHealth -=_mcStats.CritChance(WeaponDamage);
        }
    }
}
