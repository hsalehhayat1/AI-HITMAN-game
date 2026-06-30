using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private int HP = 100;

    private Animator animator;
    private NavMeshAgent navAgent;

    public bool isDead;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();

        navAgent.stoppingDistance = 2.5f;
        navAgent.autoBraking = true;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        HP -= damageAmount;

        if (HP <= 0)
        {
            isDead = true;

            // ✅ CLOUD STATS UPDATE
            CloudStatsManager cloud = FindObjectOfType<CloudStatsManager>();

            if (cloud != null)
            {
                cloud.totalKills++;
                cloud.SendStats();
            }

            int randomValue = Random.Range(0, 2);

            if (randomValue == 0)
                animator.SetTrigger("DIE1");
            else
                animator.SetTrigger("DIE2");

            navAgent.isStopped = true;
            navAgent.enabled = false;

            SoundManager.Instance.zombieChannel.PlayOneShot(
                SoundManager.Instance.zombieDeath
            );
        }
        else
        {
            animator.SetTrigger("DAMAGE");

            SoundManager.Instance.zombieChannel.PlayOneShot(
                SoundManager.Instance.zombieHurt
            );
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 130f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 131f);
    }
}