using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // 총알을 전진 방향으로 이동시킵니다.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
