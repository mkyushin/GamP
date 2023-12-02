using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절을 위한 변수

    void Update()
    {
        // 수평 축 이동 (좌우)
        float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalMovement = horizontalInput * moveSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement, 0f, 0f);

        // 수직 축 이동 (상하)
        float verticalInput = Input.GetAxis("Vertical");
        float verticalMovement = verticalInput * moveSpeed * Time.deltaTime;
        transform.Translate(0f, verticalMovement, 0f);
    }
}
