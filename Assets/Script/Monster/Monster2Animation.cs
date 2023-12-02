using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2Animation : MonoBehaviour
{
    private Animator anim;
    public Transform player;
    public Transform monster2;


    public GameObject clue2;
    public GameObject axe;




    public float distanceRange;
    public float monster2Speed;
    public float attackRange;

    private bool isDead = false; // 몬스터가 사망한 경우 true로 설정

    public void Monster2Run()
    {
        if (isDead)
        {
            axe.SetActive(false);
            return; // 사망한 경우 더 이상 실행하지 않음
        }

        Vector3 playerLoc = player.position;
        Vector3 monsterLoc = monster2.position;
        Vector3 direction = (playerLoc - monsterLoc).normalized;
        float distance = Vector3.Distance(playerLoc, monsterLoc);  

        if ((attackRange < distance) && (distance < distanceRange))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", true);
            monster2.Translate(direction * monster2Speed * Time.deltaTime, Space.World);
            monster2.LookAt(player);
        }

    }

    private void OnTriggerEnter(Collider monster)
    {
        if (monster.CompareTag("AxeCollider"))
        {
            isDead = true; // 사망 상태로 설정
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", false);

            anim.SetBool("isDie", true);
            Debug.Log("asdfasdf");
            
            // 1초 뒤에 monster2 오브젝트를 비활성화하는 코루틴 실행
            //StartCoroutine(DeactivateMonster2AfterDelay(2.2f));
            //clue2.SetActive(true);
            
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Monster2Run();
    }

    // 1초 뒤에 monster2 오브젝트를 비활성화하는 코루틴
    private IEnumerator DeactivateMonster2AfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        monster2.gameObject.SetActive(false);
        
        axe.SetActive(false);
    }
}
