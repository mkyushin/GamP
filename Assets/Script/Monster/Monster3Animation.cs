using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3Animation : MonoBehaviour
{
    private Animator anim;
    public Transform player;
    public Transform monster3;
    public Transform destination;
    public Transform cabinet;






    public float distanceRange;
    public float monster3Speed;
    bool isEntered = false;




    public void Monster3Run()
    {
        Vector3 playerLoc = player.position;
        Vector3 monsterLoc = monster3.position;
        Vector3 direction = (playerLoc - monsterLoc).normalized;
        float distance = Vector3.Distance(playerLoc, monsterLoc);


        Vector3 desinationLoc = destination.position;
        Vector3 cabinetLoc = cabinet.position;
        float distanceCabient = Vector3.Distance(playerLoc,cabinetLoc);  
        Vector3 directionDestination = (monsterLoc - desinationLoc).normalized;

        if (distance < distanceRange)
        {
            if(isEntered)
            {
                return;
            }
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", true);
            monster3.Translate(direction * monster3Speed * Time.deltaTime, Space.World);
            monster3.LookAt(player);
        }
        if(distanceCabient<3)
        {
          monster3.Translate(directionDestination * monster3Speed * Time.deltaTime, Space.World); 
          isEntered = true; 
          Debug.Log("entered");
        }

    }


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Monster3Run();
    }

}
