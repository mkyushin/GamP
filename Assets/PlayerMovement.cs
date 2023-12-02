using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // 이동 속도 조절을 위한 변수
    public float gravity = -9.8f; // 중력 값
    public float jumpHeight = 3f; // 점프 높이

    public Transform groundCheck; // 바닥 검사용 위치
    public float groundDistance = 0.4f; // 바닥 검사 거리
    public LayerMask groundMask; // 바닥 레이어 마스크

    CharacterController characterController;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 바닥에 닿았는지 여부 확인
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 바닥에 닿았을 때 중력 초기화
        }

        float horizontalInput = Input.GetAxis("Horizontal"); // 수평 이동 입력
        float verticalInput = Input.GetAxis("Vertical"); // 수직 이동 입력

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput; // 이동 방향 계산
        characterController.Move(move * speed * Time.deltaTime); // 실제 이동

        // 점프
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime); // 중력 적용
    }
}
