using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    void Raycast()
    {
        // 마우스 왼쪽 버튼을 클릭할 때 Raycasting을 사용하여 오브젝트를 선택합니다.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Raycasting을 사용하여 마우스 클릭 지점에서 오브젝트와의 충돌을 검출합니다.
            if (Physics.Raycast(ray, out hit))
            {
                // 충돌한 오브젝트를 선택 또는 처리합니다.
                GameObject selectedObject = hit.collider.gameObject;
                Debug.Log("클릭된 오브젝트 이름은: " + selectedObject.name);

                

                // 여기서 선택된 오브젝트에 대한 동작을 수행합니다.
                // 예: selectedObject.GetComponent<MyObjectScript>().Select();
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }
}
