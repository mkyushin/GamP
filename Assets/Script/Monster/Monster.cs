using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

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
    public float attackDamage;

    // Const Value
    private const float Tick = 0.2f;
    private const float DestroyDelay = 3f;
    
    // Player Position
    private Transform _playerTransform;
     
    // Components
    private Animator _anim;
    private NavMeshAgent _nav;
    [SerializeField] private GameObject _attackPart;
    
    // State
    private bool _isDetectPlayer;
    private bool _isDead;
    
    // Animation Hash 
    private static readonly int IsDetectPlayer = Animator.StringToHash("IsDetectPlayer");
    private static readonly int IsLostPlayer = Animator.StringToHash("IsLostPlayer");
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private static readonly int Health = Animator.StringToHash("Health");
    private static readonly int Attack = Animator.StringToHash("Attack");

    // coroutine
    private Coroutine _attackCoroutine;
    

    private void Awake()
    {
        // Get Player Position
        _playerTransform = GameObject.FindWithTag("Player").transform;
        
        // Get Components
        _anim = GetComponent<Animator>();
        _nav = GetComponent<NavMeshAgent>();
        
        // Init Attack Part
        _attackPart.SetActive(false);
        _attackPart.GetComponent<MonsterAttackPart>().SetMonster(this);
        
        // Set Stat
        curSpeed = walkSpeed;
        _nav.speed = curSpeed;
        _nav.stoppingDistance = attackRange;
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

    #region Detect Player

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
                    _attackCoroutine = StartCoroutine(AttackCoroutine());
                    yield break;
                }
                yield return new WaitForSeconds(Tick);
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
                    if (_attackCoroutine != null) StopCoroutine(_attackCoroutine);
                    yield break;
                }
                yield return new WaitForSeconds(Tick);
            }
        }


    #endregion
    
    #region Attack

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            // If distance between monster and player is less than attackRange,
            // monster attack player
            float distance = Vector3.Distance(transform.position, _playerTransform.position);
            if (distance < attackRange)
            {
                Debug.Log("Attack");
                _anim.SetTrigger(Attack);
                yield break;
            }
            yield return new WaitForSeconds(Tick);
        }
    }
    
    public void ApplyAttack(Player player)
    {
        Debug.Log("ApplyAttack");
        player.GetDamaged(attackDamage);
        _attackPart.SetActive(false);
    }

    #endregion

    #region Damaged

    public void GetDamaged(float damage)
    {
        if(health <= 0) return;
        
        health -= damage;
        _anim.SetFloat(Health, health);
        if (health <= 0)
        {
            _nav.enabled = false;
            _isDead = true;
            _anim.SetBool(IsDead, true);
                
            StopAllCoroutines();
        }
    }

    #endregion

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

    public void AttackStart()
    {
        Debug.Log("AttackStart");
        _attackPart.SetActive(true);
    }
    
    public void AttackEnd()
    {
        Debug.Log("AttackEnd");
        _attackPart.SetActive(false);
        
        // Restart Attack Coroutine
        _attackCoroutine = StartCoroutine(AttackCoroutine());
    }
    
    #endregion
    

    

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
