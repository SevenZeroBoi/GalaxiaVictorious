using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMainScript : MonoBehaviour
{
    [Header("Main")]
    public string enemyName;
    public float enemyHealth;
    public Animator enemyAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullets")
        {
            enemyHealth -= System.Convert.ToInt32(collision.gameObject.name);
        }
    }

    public virtual void EnemyGotStunned() { }
    public virtual void EnemyLost() { }
}
