using UnityEngine;

public class enemyRangeAnimationMethods : MonoBehaviour {

    [SerializeField] enemyRangeMovementBehaviour _enemyRangeMovementBehaviour;
    [SerializeField] Rigidbody _rigid;
    [SerializeField] GameObject projectile;


    void Backstep(float backstepPower)
    {
        _rigid.AddForce(transform.forward * Time.deltaTime * -60000 * backstepPower);
    }

    void InstantiateProjectile()
    {
        projectile.transform.parent = null;
        projectile.transform.position = transform.position+new Vector3(0f,1.5f,0f);
        projectile.transform.rotation = transform.rotation;
        projectile.gameObject.SetActive(true);
    }

    void ActivateMovement(int i)
    {
        if (i == 1)
            _enemyRangeMovementBehaviour.enabled = true;
        else if (i == 0)
            _enemyRangeMovementBehaviour.enabled = false;
    }
    


}
