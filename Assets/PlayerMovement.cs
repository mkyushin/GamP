using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �̵� �ӵ� ������ ���� ����
    public float gravity = -9.8f; // �߷� ��
    public float jumpHeight = 3f; // ���� ����

    public Transform groundCheck; // �ٴ� �˻�� ��ġ
    public float groundDistance = 0.4f; // �ٴ� �˻� �Ÿ�
    public LayerMask groundMask; // �ٴ� ���̾� ����ũ

    CharacterController characterController;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // �ٴڿ� ��Ҵ��� ���� Ȯ��
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // �ٴڿ� ����� �� �߷� �ʱ�ȭ
        }

        float horizontalInput = Input.GetAxis("Horizontal"); // ���� �̵� �Է�
        float verticalInput = Input.GetAxis("Vertical"); // ���� �̵� �Է�

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput; // �̵� ���� ���
        characterController.Move(move * speed * Time.deltaTime); // ���� �̵�

        // ����
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime); // �߷� ����
    }
}
