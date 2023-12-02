using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuButtonToggle : MonoBehaviour
{
    public GameObject menu; // �Ѱ� �� �޴��� ������ ����
    public Transform head;
    public float spawnDistance;




    public InputActionReference showButton;



    void Update()
    {

        
        // ���� ��Ʈ�ѷ��� �޴� ��ư�� ������
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
