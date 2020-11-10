using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public Transform target;
    public GameObject gunObject;
    public float attackRange = 8.0f;

    private NavMeshAgent _agent = null;
 

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        if(Vector3.SqrMagnitude(_agent.transform.position - target.transform.position) < attackRange * attackRange)
        {
            _agent.isStopped = true;
            _agent.transform.LookAt(target);
      
        }
        else
        {
            _agent.isStopped = false;
            _agent.SetDestination(target.position);
        }
    }
}
