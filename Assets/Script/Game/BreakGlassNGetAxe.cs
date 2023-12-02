using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlassNGetAxe : MonoBehaviour
{
    public GameObject glass;

    public Transform player;
    public Transform axeBox;




    private int spacebarCount = 0;


    public void DestroyGlass()
    {
        Vector3 playerLoc = player.position;
        Vector3 axeBoxLoc = axeBox.position;
        

        float pVaxeboxDistance = Vector3.Distance(playerLoc, axeBoxLoc);
        
        if (Input.GetKeyDown(KeyCode.Space) && pVaxeboxDistance<= 7.0f)
        {
            spacebarCount++; // 스페이스바가 눌릴 때마다 카운트 증가
        }

        if (spacebarCount >= 10)
        {
            Debug.Log("스페이스바가 10번 눌렸습니다!");
            glass.SetActive(false);
            UIManager.uIManagerInstance.layerMessages_txt.gameObject.SetActive(false);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       DestroyGlass();
        
    }
}
