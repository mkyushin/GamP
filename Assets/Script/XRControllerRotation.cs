using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XRControllerRotation : MonoBehaviour
{
    public XRNode inputSource;
    public float rotationSpeed = 45.0f;

    private XRController xrController;

    void Start()
    {
        xrController = GetComponent<XRController>();
    }

    void Update()
    {
        // ������ ��Ʈ�ѷ��� ���̽�ƽ �Է� ����
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        // ���̽�ƽ ȸ�� ����
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickValue);
        float rotationAmount = joystickValue.x * rotationSpeed * Time.deltaTime;

        // ĳ���� ȸ��
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
