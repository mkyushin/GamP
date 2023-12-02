using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ������ ���� ����

    void Update()
    {
        // ���� �� �̵� (�¿�)
        float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalMovement = horizontalInput * moveSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement, 0f, 0f);

        // ���� �� �̵� (����)
        float verticalInput = Input.GetAxis("Vertical");
        float verticalMovement = verticalInput * moveSpeed * Time.deltaTime;
        transform.Translate(0f, verticalMovement, 0f);
    }
}
