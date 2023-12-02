using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Monster : MonoBehaviour
{
    // Stat
    public float health;
    public float curSpeed;
    public float walkSpeed;
    public float runSpeed;
    // if player is in this range, monster detect player, and chase player
    public float detectPlayerRange;
    public float attackRange;
    public float attackSpeed;
    public float attackDamage;

    // Const Value
    private const float DetectPlayerTick = 0.2f;
    private const float DestroyDelay = 3f;
    
    // Player Position
    private Transform _playerTransform;
     
    // Components
    private Animator _anim;
    private NavMeshAgent _nav;
    
    // State
    private bool _isDetectPlayer;
    private bool _isAttacking = false;
    private bool _isRunning = false;
    private bool _isDead = false;
    
    // Animation Hash 
    private static readonly int IsDetectPlayer = Animator.StringToHash("IsDetectPlayer");
    private static readonly int IsLostPlayer = Animator.StringToHash("IsLostPlayer");
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private static readonly int Health = Animator.StringToHash("Health");

    private void Awake()
    {
        // Get Player Position
        _playerTransform = GameObject.FindWithTag("Player").transform;
        
        // Get Components
        _anim = GetComponent<Animator>();
        _nav = GetComponent<NavMeshAgent>();
        
        // Set Stat
        curSpeed = walkSpeed;
        _nav.speed = curSpeed;
        _anim.SetFloat(Health, health);
        
        // Start Coroutine
        StartCoroutine(IsPlayerInsideOfDetectRange());
    }

    
    private void Update()
    {
        if(_isDead) return;
        
        if (_isDetectPlayer)
        {
            _nav.SetDestination(_playerTransform.position);
        }
    }

    private IEnumerator IsPlayerInsideOfDetectRange()
    {
        while (true)
        {
            // If distance between monster and player is less than detectPlayerRange,
            // monster detect player
            // monster will follow player until monster is dead or player is out of detectPlayerRange
            float distance = Vector3.Distance(transform.position, _playerTransform.position);
            if (distance < detectPlayerRange)
            {
                curSpeed = walkSpeed;
                _nav.speed = curSpeed;
                
                _anim.SetTrigger(IsDetectPlayer);

                StartCoroutine(IsPlayerOutsideOfDetectRange());
                yield break;
            }
            yield return new WaitForSeconds(DetectPlayerTick);
        }
    }

    private IEnumerator IsPlayerOutsideOfDetectRange()
    {
        while (true)
        {
            // If distance between monster and player is greater than detectPlayerRange,
            // monster stop detect player
            float distance = Vector3.Distance(transform.position, _playerTransform.position);
            if (distance > detectPlayerRange)
            {
                _isDetectPlayer = false;
                _anim.SetTrigger(IsLostPlayer);
                
                // Stop NavMeshAgent
                _nav.SetDestination(transform.position);

                StartCoroutine(IsPlayerInsideOfDetectRange());
                yield break;
            }
            yield return new WaitForSeconds(DetectPlayerTick);
        }
    }

    public void OnDrawGizmos()
    {
        // Show Detect Player Range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectPlayerRange);
        
        // Show Attack Range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


    #region CallOnAnimationEvent
    
    public void ScreamEnd()
    {
        Debug.Log("ScreamEnd");
        _isDetectPlayer = true;
    }

    public void StartRunning()
    {
        Debug.Log("StartRunning");
        curSpeed = runSpeed;
        _nav.speed = curSpeed;
    }

    public void DeadCompletely()
    {
        Debug.Log("DeadCompletely");
        Destroy(gameObject, DestroyDelay);
    }
    
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(health <= 0) return;
        
        if(other.TryGetComponent(out Bullet bullet))
        {
            health -= bullet.damage;
            _anim.SetFloat(Health, health);
            if (health <= 0)
            {
                _nav.enabled = false;
                _isDead = true;
                _anim.SetBool(IsDead, true);
                
                StopAllCoroutines();
            }
        }
    }
}
