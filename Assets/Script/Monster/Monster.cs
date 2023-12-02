using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    // Stat
    public float health;
    public float speed;
    // if player is in this range, monster detect player, and chase player
    public float detectPlayerRange;
    public float attackRange;
    public float attackSpeed;

    // Const Value
    private const float DetectPlayerTick = 0.2f;

    // Player Position
    private Transform _playerTransform;
     
    // Components
    private Animator _anim;
    private NavMeshAgent _nav;
    
    // State
    private bool _isDetectPlayer;
    private bool _isAttacking = false;
    private bool _isRunning = false;

    private void Awake()
    {
        // Get Player Position
        _playerTransform = GameObject.FindWithTag("Player").transform;
        
        // Get Components
        _anim = GetComponent<Animator>();
        _nav = GetComponent<NavMeshAgent>();
        
        // Set Stat
        _nav.speed = speed;
        
        // Start Coroutine
        StartCoroutine(IsPlayerInsideOfDetectRange());
    }

    
    private void Update()
    {
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
                _isDetectPlayer = true;

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
    
    
}
