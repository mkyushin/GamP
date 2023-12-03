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
            // 등록된 메뉴 버튼 입력 액션에 대한 콜백 함수를 설정합니다.
            leftController.inputDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonState);
            if (menuButtonState)
            {
                ToggleCubeObject();
            }
        }
    }

    private void Update()
    {
        // 매 프레임마다 메뉴 버튼의 상태를 체크하여 Cube 오브젝트를 토글합니다.
        leftController.inputDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonState);
        if (menuButtonState)
        {
            ToggleCubeObject();
        }
    }

    private void ToggleCubeObject()
    {
        // Cube 오브젝트의 활성/비활성 상태를 변경합니다.
        cubeObject.SetActive(!cubeObject.activeSelf);
    }

}
