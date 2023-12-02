using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float rotationSpeed = 2.0f; // 오브젝트 회전 속도 조절을 위한 변수
    public Transform playerObject; // 플레이어(또는 오브젝트)의 Transform 컴포넌트

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 수평 이동 입력
        float verticalInput = Input.GetAxis("Vertical"); // 수직 이동 입력

        // 플레이어(또는 오브젝트) 이동
        Vector3 moveDirection = playerObject.forward * verticalInput + playerObject.right * horizontalInput;
        playerObject.Translate(moveDirection * Time.deltaTime);

        // 마우스 회전 (수평 회전만)
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        playerObject.Rotate(Vector3.up * mouseX);
    }
}
