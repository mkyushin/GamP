using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using CommonUsages = UnityEngine.XR.CommonUsages;
public class VRPlayerMovement : MonoBehaviour
{
    private XRController xrController;
    private CharacterController characterController;

    void Start()
    {
        // VR 왼쪽 컨트롤러의 XRController 컴포넌트 가져오기
        xrController = GetComponent<XRController>();

        // 큐브가 플레이어로 사용될 때 필요한 CharacterController 컴포넌트 가져오기
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // VR 왼쪽 조이스틱 입력 받기
        Vector2 thumbstickValue;
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out thumbstickValue))
        {
            // 큐브를 이동시키기
            Vector3 moveDirection = new Vector3(thumbstickValue.x, 0f, thumbstickValue.y);
            characterController.Move(moveDirection * Time.deltaTime * 5f);
        }
    }
}
