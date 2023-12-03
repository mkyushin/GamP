using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteractMessage : MonoBehaviour
{
    public Transform player;
    public Transform[] objects;

    


    public float distanceRange ;

    public GameObject door1;
    public GameObject door1Opened;
    public GameObject axeGlass;
    public Transform door2_1Transform;
    public GameObject door2_1;
    public GameObject door2_1Opened;

    public GameObject door2_2;
    public GameObject door2_2Opened;


    
    public GameObject cabinetDoor;
    public GameObject cabinetDoorOpened;
    public Button useClue3;
    public GameObject Layer2;


    public GameObject axe;
    
    public GameObject axeSpwaned;

    private int spacebarCount = 0;






    private bool isDoor1Opened = false;


    

    public void VRDoor1_Interaction()
    {
        Vector3 playerLoc = player.position;
        Vector3 objLoc = door1.transform.position;
        float distance = Vector3.Distance(playerLoc, objLoc);

        if (distance <= distanceRange && !isDoor1Opened)     //문 범위에 있고, 문이 닫혀있으면, 
        {
            UIManager.uIManagerInstance.MessageDisplay(0);      //문을 여세요 메세지 출력
            UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(true);

       
        }
        if (isDoor1Opened == true)     //문이 열려있으면,          
        {
            UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(false);
        }


    }


    public void MakeDoor1Opened()     // door1 클릭시에 
    {
        isDoor1Opened = true;
        door1.SetActive(false);
        door1Opened.SetActive(true);

    }









    public void ShowMessage()
    {
        
        for (int i = 0; i < objects.Length; i++)
        {
            Transform obj = objects[i];
            Vector3 playerLoc = player.position;
            Vector3 objLoc = obj.position;
            float distance = Vector3.Distance(playerLoc, objLoc);
            //Debug.Log(distance);
        

                if(obj.tag=="Door1" &&  (distance<= distanceRange))
                {   

                    UIManager.uIManagerInstance.MessageDisplay(0);    //문을 여세요
                    if (!UIManager.uIManagerInstance.layerMessages_txt.gameObject.activeSelf) 
                    {
                        UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(true); 
                        StartCoroutine(HideMessageAfterDelay(1.0f));
                        
                    }
                    if (Input.GetKeyDown(KeyCode.E) )
                    {   
                        door1.SetActive(false);
                        door1Opened.SetActive(true);
                    }
                    
                    // if (Input.GetKeyDown(KeyCode.E) && door1Opened.activeSelf )
                    // {   
                    //     door1.SetActive(true);
                    //     door1Opened.SetActive(false);
                    // } 
                     


                }

                if(obj.tag=="AxeBox" &&  (distance<= distanceRange) )
                {
                    UIManager.uIManagerInstance.MessageDisplay(2);  // spacebar를 연타해 유리를 깨세요. 

                    if (!UIManager.uIManagerInstance.layerMessages_txt.gameObject.activeSelf) 
                    {
                        UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(true); 
                        StartCoroutine(HideMessageAfterDelay(1.0f));
                        
                    }
                    if (Input.GetKeyDown(KeyCode.T) )
                    {   
                        spacebarCount++;
                        if (spacebarCount == 10)
                        {
                            axeGlass.SetActive(false);
                            axe.SetActive(false);
                            axeSpwaned.SetActive(true);

                        }
                        

                    }

                   
                }



                if(obj.tag=="Door2-1" &&  (distance<= distanceRange) )
                {
                
                    

                    UIManager.uIManagerInstance.MessageDisplay(7);  //문잠김

                    if (!UIManager.uIManagerInstance.layerMessages_txt.gameObject.activeSelf) 
                    {
                        UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(true); 
                        StartCoroutine(HideMessageAfterDelay(1.0f));
                        
                    } 
                }
                if(obj.tag=="Door2-2" &&  (distance<= distanceRange) )
                {
                
                    

                    UIManager.uIManagerInstance.MessageDisplay(0);  //e로 문여셈

                    if (!UIManager.uIManagerInstance.layerMessages_txt.gameObject.activeSelf) 
                    {
                        UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(true); 
                        StartCoroutine(HideMessageAfterDelay(1.0f));
                        
                    } 
                    if (Input.GetKeyDown(KeyCode.E) )
                    {   
                        door2_2.SetActive(false);
                        door2_2Opened.SetActive(true);
                    }
                }







                if(obj.tag=="CabinetDoor" &&  (distance<= distanceRange) )
                {
                    UIManager.uIManagerInstance.MessageDisplay(1);  

                    UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {   
                        UIManager.uIManagerInstance.MessageDisplay(6);  // c를 눌러 캐비넷을 닫으세요


                        cabinetDoor.SetActive(false);
                        cabinetDoorOpened.SetActive(true);
                    }
                    if (Input.GetKeyDown(KeyCode.C))
                    {   
                        UIManager.uIManagerInstance.MessageDisplay(7);
                        cabinetDoor.SetActive(true);
                        cabinetDoorOpened.SetActive(false);
                    }                    
                    
                }
                if(obj.tag=="DoorLock" &&  (distance<= distanceRange)  )
                {
                    UIManager.uIManagerInstance.MessageDisplay(3);  
                    if (!UIManager.uIManagerInstance.layerMessages_txt.gameObject.activeSelf)
                    {
                        UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(true);
                        StartCoroutine(HideMessageAfterDelay(1.0f));

                    }  
                }


        }
    }











    public void useClue3Click()
    {
        Vector3 playerLoc = player.position;
        Vector3 door2_1Loc = door2_1Transform.position;
        float distance = Vector3.Distance(playerLoc, door2_1Loc);
        if(distance< distanceRange)
        {
            door2_1.SetActive(false);
            door2_1Opened.SetActive(true);
            UIManager.uIManagerInstance.MessageDisplay(8);   // 문이 열렸습니다.
            if (!UIManager.uIManagerInstance.layerMessages_txt.gameObject.activeSelf)
            {
                UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(true);
                StartCoroutine(HideMessageAfterDelay(1.0f));

            }
            Layer2.SetActive(false);
        }

        
    }






















    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        useClue3.onClick.AddListener(useClue3Click);
    }

    // Update is called once per frame
    void Update()
    {
        ShowMessage();

        VRDoor1_Interaction();

    }
}
