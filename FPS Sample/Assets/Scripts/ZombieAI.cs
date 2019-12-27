using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
	public enum ZombieState
	{
		Idle,
		Chase,
		Attack
	}
	
	public bool isAlive;
	private bool chase;
	private bool attack;
	
	public ZombieState currentState;
	
	public GameObject target;
	public float distanceToChase;
	public float distanceToAttack;
	
	public Animator animator;
	public NavMeshAgent agent;
	
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(isAlive)
		{
			SetStates();
			UpdateAnimator();
			
			if(currentState == ZombieState.Idle)
			{
				Idle();
			}
			if(currentState == ZombieState.Chase)
			{
				Chase();
			}
			if(currentState == ZombieState.Attack)
			{
				Attack();
			}
		}
    }
	
	void SetStates()
	{
		if(Vector3.Distance(transform.position, target.transform.position) > distanceToChase)
		{
			currentState = ZombieState.Idle;
		}
		if(Vector3.Distance(transform.position, target.transform.position) > distanceToAttack)
		{
			currentState = ZombieState.Chase;
		}
		if(Vector3.Distance(transform.position, target.transform.position) < distanceToAttack)
		{
			currentState = ZombieState.Attack;
		}
	}
	
	void UpdateAnimator()
	{
		animator.SetBool("chase", chase);
		animator.SetBool("attack", attack);
	}
	
	void Idle()
	{
		chase = false;
		attack = false;
	}
	
	void Chase()
	{
		attack = false;
		chase = true;
		agent.SetDestination(target.transform.position);
	}
	
	void Attack()
	{
		chase = false;
		attack = true;
		agent.SetDestination(target.transform.position);
	}
}
