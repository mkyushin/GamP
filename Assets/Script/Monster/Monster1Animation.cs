using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Animation : MonoBehaviour
{
    private Animation anim;

    public void Monster1Anim()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // walk 애니메이션 재생
            anim.Play("Run");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // walk 애니메이션 재생
            anim.Play("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // walk 애니메이션 재생
            anim.Play("Attack2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // walk 애니메이션 재생
            anim.Play("Death");
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            // walk 애니메이션 재생
            anim.Play("0-idle_agressive");
        }

    }

    void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
        Monster1Anim();

    }
}
