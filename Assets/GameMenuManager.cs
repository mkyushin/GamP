using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuButtonToggle : MonoBehaviour
{
    public GameObject menu; // 켜고 끌 메뉴를 연결할 변수
    public Transform head;
    public float spawnDistance;




    public InputActionReference showButton;



    void Update()
    {

        
        // 왼쪽 컨트롤러의 메뉴 버튼이 눌리면
        if (showButton.action.triggered == true) 
        {
            Debug.Log("pressed");  
            menu.SetActive(!menu.activeSelf);
            
            menu.transform.position = head.position+ new Vector3(head.forward.x, 0, head.forward.z).normalized*spawnDistance;



        }

        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;


    }
}
