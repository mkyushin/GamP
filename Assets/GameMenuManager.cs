using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonUsages = UnityEngine.XR.CommonUsages;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class GameMenuManager : MonoBehaviour
{
    public XRController leftController;
    public GameObject cubeObject;

    private void Start()
    {
        if (leftController == null)
        {
            Debug.LogError("Left controller is not assigned!");
        }
        else
        {
            // ��ϵ� �޴� ��ư �Է� �׼ǿ� ���� �ݹ� �Լ��� �����մϴ�.
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonState);
            if (menuButtonState)
            {
                ToggleCubeObject();
            }
        }
    }

    private void Update()
    {
        // �� �����Ӹ��� �޴� ��ư�� ���¸� üũ�Ͽ� Cube ������Ʈ�� ����մϴ�.
        leftController.inputDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonState);
        if (menuButtonState)
        {
            ToggleCubeObject();
        }
    }

    private void ToggleCubeObject()
    {
        // Cube ������Ʈ�� Ȱ��/��Ȱ�� ���¸� �����մϴ�.
        cubeObject.SetActive(!cubeObject.activeSelf);
    }

}
