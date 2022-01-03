using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }

    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
        {
            animator.SetTrigger("Hurt");
        }
    }
}
