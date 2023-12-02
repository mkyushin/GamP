using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XRControllerMovement : MonoBehaviour
{
    public XRNode inputSource;
    public float speed = 1.0f;

    private XRController xrController;
    private CharacterController characterController;

    void Start()
    {
        xrController = GetComponent<XRController>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // �޼� ��Ʈ�ѷ��� ���̽�ƽ �Է� ����
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickValue);

        // �̵� ���� ����
        Vector3 moveDirection = new Vector3(joystickValue.x, 0, joystickValue.y);
        moveDirection = transform.TransformDirection(moveDirection);

        // ĳ���� �̵�
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }
}
