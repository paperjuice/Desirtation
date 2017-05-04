using UnityEngine;

public class enemyRangeAttackBehaviour : MonoBehaviour {

    [SerializeField] Animator anim;
    [SerializeField] enemyRangeMovementBehaviour _enemyRangeMovementBehaviour;
    [SerializeField] string[] attackStringAnimation;

    float currentTimeBetweenAttacks=0f;
    float endTimeBetweenAttacks=2f;


    public void IsInRange(bool inRange)
    {
        int isAttacking=0;

        if (inRange)
        {
            currentTimeBetweenAttacks += Time.deltaTime;

            if (currentTimeBetweenAttacks >= endTimeBetweenAttacks && isAttacking==0)
            {
                currentTimeBetweenAttacks = 0;
                isAttacking = Random.Range(1, 10);
                
            }

            if (isAttacking < 7 && isAttacking !=0)
            {
                anim.SetTrigger(attackStringAnimation[0]);
                
                isAttacking = 0;
            }

        }
    }



}
