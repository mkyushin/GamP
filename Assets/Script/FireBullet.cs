using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // �Ѿ��� ���� �������� �̵���ŵ�ϴ�.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
