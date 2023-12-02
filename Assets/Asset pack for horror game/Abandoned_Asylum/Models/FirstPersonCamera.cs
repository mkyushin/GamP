using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float rotationSpeed = 2.0f; // ������Ʈ ȸ�� �ӵ� ������ ���� ����
    public Transform playerObject; // �÷��̾�(�Ǵ� ������Ʈ)�� Transform ������Ʈ

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // ���� �̵� �Է�
        float verticalInput = Input.GetAxis("Vertical"); // ���� �̵� �Է�

        // �÷��̾�(�Ǵ� ������Ʈ) �̵�
        Vector3 moveDirection = playerObject.forward * verticalInput + playerObject.right * horizontalInput;
        playerObject.Translate(moveDirection * Time.deltaTime);

        // ���콺 ȸ�� (���� ȸ����)
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        playerObject.Rotate(Vector3.up * mouseX);
    }
}
