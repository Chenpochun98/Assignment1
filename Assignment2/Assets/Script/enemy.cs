using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public float maxSpeed = 4.0f;
    public Transform waypoint;
    public float maxHealth = 100.0f;

    private NavMeshAgent _agent;
    private Animator _animator;
    private float dividedSpeed = 0.0f;
    private bool isDead = false;
    private waypointmanager.path _path;
    private int _currentWaypoint = 0;
    private float _currentHealth = 0.0f;
    private float deathClipLength;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        if(_animator == null)
        {
            Debug.LogError("animator compoinaent does exists");
            return;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();

        if(_path == null || _path.Wapoints == null || _path.Wapoints.Count <= _currentWaypoint)
        {
            return;
        }

        Transform destination = _path.Wapoints[_currentWaypoint];
        _agent.SetDestination(destination.position);

        if((transform.position - destination.position).sqrMagnitude < 3.0f * 3.0f)
        {
            _currentWaypoint++;
        }
    }

    private void UpdateAnimation()
    {
        _animator.SetFloat("enemyspeed", _agent.velocity.magnitude * dividedSpeed);
        _animator.SetBool("isdead", isDead);
    }

    public void Init(waypointmanager.path path)
    {
        _path = path;
        _currentHealth = maxHealth;

        _agent = GetComponent<NavMeshAgent>();

        if (_agent != null)
        {
            _agent.SetDestination(waypoint.position);
            _agent.speed = maxSpeed;
        }
        dividedSpeed = 1 / maxSpeed;

        AnimationClip[] animations = _animator.runtimeAnimatorController.animationClips;
        if (animations == null || animations.Length <= 0)
        {
            Debug.Log("animations Error");
            return;
        }

        for (int i = 0; i < animations.Length; ++i)
        {
            if (animations[i].name == "Death From Right")
            {
                deathClipLength = animations[i].length;
                break;
            }
        }
    }

    public float GetHealth()
    {
        return _currentHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0.0f)
        {
            StartCoroutine("Kill");
        }
    }

    public IEnumerator Kill()
    {
        isDead = true;

        yield return new WaitForSeconds(deathClipLength);
        ResetAndRecycle();
    }

   private void ResetAndRecycle()
   {
        _currentWaypoint = 0;
        isDead = false;
        _currentHealth = maxHealth;
        transform.rotation = Quaternion.identity;
        Destroy(_agent);
        ServiceLocator.Get<ObjectPoolManager>().RecycleObject(gameObject);
   }
}
