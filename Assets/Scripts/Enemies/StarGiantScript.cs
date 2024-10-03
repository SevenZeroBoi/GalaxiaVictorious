using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGiantScript : EnemyMainScript
{
    [Header("Character Sub Script")]
    public string currentAttackingPhase;

    [Header("Falling Star Attack")]
    public GameObject fallingStar;
    public GameObject fallingStarSpawner;
    public float rangebetweenstar;
    public float starcounts;
    void StarfallAttack()
    {
        for (int i = 0; i < starcounts; i++)
        {
            GameObject skillObject = PoolingManager.instance.GetFromPool("fallingStar", fallingStar, transform.position + (Vector3.left*(i*rangebetweenstar)), Quaternion.identity);
        }

    }

    void SmashAttack()
    {
        int RandomSide = Random.Range(0, 2);
        if (RandomSide == 0)
        {
            enemyAnim.SetTrigger("SmashTop");
        }
        else
        {
            enemyAnim.SetTrigger("SmashDown");
        }
    }

    [Header("Starburst Attack")]
    public GameObject[] StarburstSpawner;
    void StarburstAttack()
    {
        
    }

    void LittleStarwalkAttack()
    {

    }

    void DeathAttack()
    {

    }
}
