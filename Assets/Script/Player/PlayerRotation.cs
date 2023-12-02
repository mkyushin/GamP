using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float xRotate_Player, yRotate_Player, xRotate_Camera, yRotate_Camera, xRotateMove, yRotateMove; 
    public float rotateSpeed = 50.0f; //마우스 회전 속도 계수




    public Transform playerTransform;
    public Transform cameraTransform;



    void mouseRotation()
    {
        if(Input.GetMouseButton(1)) // 오른쪽 버튼 클릭한 경우
        {
            xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

            yRotate_Player = playerTransform.eulerAngles.y + yRotateMove;
            //xRotate_Player = playerTransform.eulerAngles.x + xRotateMove; 

            yRotate_Camera = cameraTransform.eulerAngles.y + yRotateMove;
            xRotate_Camera = cameraTransform.eulerAngles.x + xRotateMove;            
            


            //xRotate = xRotate + xRotateMove;
            
            //xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정
            
            playerTransform.eulerAngles = new Vector3(0, yRotate_Player, 0);


            cameraTransform.eulerAngles = new Vector3(xRotate_Camera, yRotate_Camera, 0);
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseRotation();
        
    }
}
