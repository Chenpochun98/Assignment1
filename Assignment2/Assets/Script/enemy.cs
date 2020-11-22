using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private bool isdead;

    public Transform waypoint;
    public float maxspeed = 4.0f;
    public float speed = 5.0f;
    private float dividedspeed = 0.0f;
    private waypointmanager.path _path;
    private int _currentwaypoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agent.SetDestination(waypoint.transform.position);
            agent.speed = maxspeed;
        }
        dividedspeed = 1 / maxspeed;
    }

    // Update is called once per frame
    void Update()
    {
        Updateanimation();

        if(_path==null||_path.Wapoints==null||_path.Wapoints.Count<=_currentwaypoints)
        {
            return;
        }
        Transform destination = _path.Wapoints[_currentwaypoints];
        agent.SetDestination(destination.position);

        if((transform.position-destination.position).sqrMagnitude <3.0f*3.0f)
        {
            _currentwaypoints++; 
        }
    }

    private void Updateanimation()
    {
        animator.SetFloat("enemyspeed",agent.velocity.magnitude * dividedspeed);
        animator.SetBool("isdead", isdead);
    }

    public void Init(waypointmanager.path path)
    {
        _path = path;
    }
}
