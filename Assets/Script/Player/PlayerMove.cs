using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    public float moveSpeed = 1.0f; // 이동 속도 조절 변수
    public float jumpSpeed = 1.0f;
    public float gravity = -20.0f;
    public float yVelocity = 0;


    public Transform cameraTransform;
    public GameObject player ; 


    void wasdMove()
    {
        // WASD 키 입력을 감지하여 이동 벡터를 계산합니다.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection.Normalize(); // 대각선 이동 속도를 균등하게 조절
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *=moveSpeed;


        // 점프       
        // if(player.transform.position.y == 1.0f)
        // {
        //     yVelocity = 0;
        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         yVelocity = jumpSpeed;
        //         yVelocity += yVelocity-gravity*Time.deltaTime;
        //     }
        // }

        


        moveDirection.y = yVelocity;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

    }

    


    void Start()
    {

    }


    void Update()
    {
        wasdMove();



    }
}
