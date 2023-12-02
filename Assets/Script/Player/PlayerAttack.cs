using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform axe;
    public GameObject axeg;
    public GameObject player;

    public GameObject a;




    void Update()
    {   

        

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack1();      
            
        }
        
    }

    void Attack1()
    {

        float rotationAmount = 120.0f;

        // 회전을 적용합니다.
        axe.transform.Rotate(0, rotationAmount, 0);



        
    }







}
