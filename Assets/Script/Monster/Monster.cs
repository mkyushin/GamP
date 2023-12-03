using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Monster : MonoBehaviour
{
    // Stat
    public float curHealth;
    public float maxHealth;
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
    
    // Audio
    private AudioSource _audioSource;

    // Effect
    [SerializeField] List<GameObject> _bloodList;
    
    private void Awake()
    {
        // Get Player Position
        _playerTransform = GameObject.FindWithTag("Player").transform;
        
        // Get Components
        _anim = GetComponent<Animator>();
        _nav = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        
        // Init Attack Part
        _attackPart.SetActive(false);
        _attackPart.GetComponent<MonsterAttackPart>().SetMonster(this);
        
        // Set Stat
        curHealth = maxHealth;
        curSpeed = walkSpeed;
        _nav.speed = curSpeed;
        _nav.stoppingDistance = attackRange;
        _anim.SetFloat(Health, curHealth);
        foreach (GameObject blood in _bloodList)
            blood.SetActive(false);
        
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
                    _audioSource.Play();
                    
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
                    _audioSource.Stop();
                    
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
        if(curHealth <= 0) return;
        
        curHealth -= damage;
        _anim.SetFloat(Health, curHealth);
        
        if(curHealth/ maxHealth < 0.3f)
        {
            _bloodList[2].SetActive(true);
            _bloodList[3].SetActive(true);
        }else if(curHealth/ maxHealth < 0.6f)
        {
            _bloodList[0].SetActive(true);
            _bloodList[1].SetActive(true);
        }
        
        if (curHealth <= 0)
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
        if(Math.Abs(curSpeed - runSpeed) < 0.01f) return;
        
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
