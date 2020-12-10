using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_to : MonoBehaviour {

    // Use this for initialization

    public Transform goal;
    public Animator animator;
    bool isWalking = false;
    bool finished;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    private void Update()
    {
        agent.destination = goal.position;
        if (transform.position != goal.position && !isWalking && !finished)
        {
            Debug.Log("1");
            animator.SetBool("IdleWalk", true);
            isWalking = true;
        }
        if (transform.position.x == goal.position.x && transform.position.z == goal.position.z)
        {
            isWalking = false;
            finished = true;
            animator.SetBool("IdleWalk", false);
            animator.SetBool("IdleStand", true);
            GetComponent<NavMeshAgent>().isStopped = true;

        }
    }
}
