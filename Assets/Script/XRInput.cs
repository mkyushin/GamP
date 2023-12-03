using System.Collections;
using System.Collections.Generic;
using CommonUsages = UnityEngine.XR.CommonUsages;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class XRInput : MonoBehaviour
{
    public XRController leftController; // ���� ��Ʈ�ѷ��� ������ ����
    public GameObject uiPanel; // �Ѱ� �� UI �г��� ������ ����
    public InputFeatureUsage<bool> menuButtonUsage = CommonUsages.menuButton; // ����� ��ư�� ����

    private bool isUIToggled = false;

    void Update()
    {
        // ���� ��Ʈ�ѷ��� �޴� ��ư�� ������
        if (leftController.inputDevice.TryGetFeatureValue(menuButtonUsage, out bool menuButtonState) && menuButtonState)
        {
            ToggleUI();
        }
    }

    void ToggleUI()
    {
        isUIToggled = !isUIToggled; // UI ���¸� ����

        // UI �г��� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
        uiPanel.SetActive(isUIToggled);
    }
}
