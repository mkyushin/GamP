using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float xRotate, yRotate, xRotateMove, yRotateMove; 
    public float rotateSpeed = 50.0f; //마우스 회전 속도 계수




    public Transform cameraTransform;



    void mouseRotation()
    {
        if(Input.GetMouseButton(1)) // 오른쪽 버튼 클릭한 경우
        {
            xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

            yRotate = transform.eulerAngles.y + yRotateMove;
            xRotate = transform.eulerAngles.x + xRotateMove; 
            //xRotate = xRotate + xRotateMove;
            
            //xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정
            
            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        }
    }
    


    void Start()
    {

    }


    void Update()
    {
        mouseRotation();


    }
}
