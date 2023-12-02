using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{



    public TextMeshProUGUI  layerMessages_txt;
    public string[] gameMessages ;





    public GameObject[] layerToActivate;
    public GameObject layer5;





    public static UIManager uIManagerInstance ; 


    public void MessageDisplay(int num)
    {

        layerMessages_txt.text = gameMessages[num];
    }












    public void ClueDetailToClues()
    {
        layerToActivate[3].SetActive(false);
        layerToActivate[2].SetActive(true);
    }

    public void CluesToClueDetail()
    {
        layerToActivate[2].SetActive(false);
        layerToActivate[3].SetActive(true);
    }   

    public void CluesToMain()
    {
        layerToActivate[2].SetActive(false);
        layerToActivate[1].SetActive(true);
    }
    public void MainToClues()
    {
        layerToActivate[1].SetActive(false);
        layerToActivate[2].SetActive(true);
    }
    public void CluesToDoorFinal()
    {
        layerToActivate[2].SetActive(false);
        layerToActivate[4].SetActive(true);
    }
    public void DoorFinalToClues()
    {
        layerToActivate[4].SetActive(false);
        layerToActivate[2].SetActive(true);
    }
    public void ClueDetailToMain()
    {
        layerToActivate[3].SetActive(false);
        layerToActivate[1].SetActive(true);    
    }
    public void PasswoedToMain()
    {
        layerToActivate[4].SetActive(false);
        layerToActivate[1].SetActive(true);    
    }







    








    public void NewspaperMessageNShutdownHospital()
    {   
        MessageDisplay(4);  // 생체 실험이 일어났다고?
        layerMessages_txt.gameObject.SetActive(true);
        StartCoroutine(ShutDownMessageDelay_show(2.0f));
        

    }   



    private IEnumerator ShutDownMessageDelay_show(float delay)
    {
        yield return new WaitForSeconds(delay);
        MessageDisplay(5);
        layerMessages_txt.gameObject.SetActive(true);
        StartCoroutine(ShutDownMessageDelay_close(2.0f));

    }
    private IEnumerator ShutDownMessageDelay_close(float delay)
    {
        yield return new WaitForSeconds(delay);
        layerMessages_txt.gameObject.SetActive(false);
    }
    





    private void Awake() 
    {
        if(UIManager.uIManagerInstance == null)
        {
            UIManager.uIManagerInstance =this;
        }   
    }







    void Start()
    {
        // 1초(1000 milliseconds) 뒤에 ActivateLayer5 함수를 호출합니다.
        Invoke("ActivateLayer5", 2.0f);
    }

    void ActivateLayer5()
    {
        // layer5를 활성화합니다.
        layer5.SetActive(false);
    }



    void Update()
    {

        
    }
}
