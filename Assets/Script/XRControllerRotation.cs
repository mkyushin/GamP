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
        // 오른손 컨트롤러의 조이스틱 입력 감지
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        // 조이스틱 회전 감지
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickValue);
        float rotationAmount = joystickValue.x * rotationSpeed * Time.deltaTime;

        // 캐릭터 회전
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
