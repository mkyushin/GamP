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
        // VR ���� ��Ʈ�ѷ��� XRController ������Ʈ ��������
        xrController = GetComponent<XRController>();

        // ť�갡 �÷��̾�� ���� �� �ʿ��� CharacterController ������Ʈ ��������
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // VR ���� ���̽�ƽ �Է� �ޱ�
        Vector2 thumbstickValue;
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out thumbstickValue))
        {
            // ť�긦 �̵���Ű��
            Vector3 moveDirection = new Vector3(thumbstickValue.x, 0f, thumbstickValue.y);
            characterController.Move(moveDirection * Time.deltaTime * 5f);
        }
    }
}
