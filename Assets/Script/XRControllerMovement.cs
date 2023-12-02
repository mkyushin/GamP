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
        // 왼손 컨트롤러의 조이스틱 입력 감지
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickValue);

        // 이동 벡터 생성
        Vector3 moveDirection = new Vector3(joystickValue.x, 0, joystickValue.y);
        moveDirection = transform.TransformDirection(moveDirection);

        // 캐릭터 이동
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }
}
