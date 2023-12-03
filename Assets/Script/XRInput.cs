using System.Collections;
using System.Collections.Generic;
using CommonUsages = UnityEngine.XR.CommonUsages;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class XRInput : MonoBehaviour
{
    public XRController leftController; // 왼쪽 컨트롤러를 연결할 변수
    public GameObject uiPanel; // 켜고 끌 UI 패널을 연결할 변수
    public InputFeatureUsage<bool> menuButtonUsage = CommonUsages.menuButton; // 사용할 버튼을 지정

    private bool isUIToggled = false;

    void Update()
    {
        // 왼쪽 컨트롤러의 메뉴 버튼이 눌리면
        if (leftController.inputDevice.TryGetFeatureValue(menuButtonUsage, out bool menuButtonState) && menuButtonState)
        {
            ToggleUI();
        }
    }

    void ToggleUI()
    {
        isUIToggled = !isUIToggled; // UI 상태를 반전

        // UI 패널을 활성화 또는 비활성화
        uiPanel.SetActive(isUIToggled);
    }
}
