using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClueInteraction : MonoBehaviour
{
    public string[] clueName ;
    public string[] clueDescription;
    public Sprite[] clueImage;


    public GameObject timer;
    public GameObject showClueDetails;  //L3
    public GameObject Layer2 ;
    public GameObject layer_main;
    public GameObject backbtn_ClueDetailToMain;
    public GameObject txt_escapemessage;




    public Button myClue1;
    public Button myClue2;
    public Button myClue3;
    public Button myClue4;

    public Button useClue3;

    private bool clue1Clicked = false;
    private bool clue2Clicked = false;
    private bool clue3Clicked = false;
    private bool clue4Clicked = false;



    private void Raycast()
    {
        // 마우스 왼쪽 버튼을 클릭할 때 Raycasting을 사용하여 오브젝트를 선택합니다.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

           
            if (Physics.Raycast(ray, out hit))
            {
                
                GameObject selectedObject = hit.collider.gameObject;
                Debug.Log("클릭된 오브젝트 이름은: " + selectedObject.name);

                if(selectedObject.tag=="Clue0-1") //clue 0
                {
                    Debug.Log("이름은 : "+clueName[0] + "설명 : "+clueDescription[0]);



                    //clue의 패널 ui 상 이미지와 설명을 바꾸는 코드  
                    Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
                    imageComponents[1].sprite =  clueImage[0];       

                    TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
                    textComponents[0].text = clueDescription[0];        

                    showClueDetails.SetActive(true);
                    layer_main.SetActive(false);




                    timerOn = true;
                    timer.gameObject.SetActive(true);
                    txt_escapemessage.SetActive(true);
                    StartCoroutine(HideMessageAfterDelay(5.0f));
                    




                }
                if(selectedObject.tag=="Clue1-1")  //clue1
                {
                    Debug.Log("이름은 : "+clueName[1] + "설명 : "+clueDescription[1]);



                      
                    Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
                    imageComponents[1].sprite =  clueImage[1];       //imageComponents[0].sprite   은 L3레이어 순서에따라 Background로 되어있음. imageComponents[1]이 단서 사진 나오는 곳

                    TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
                    textComponents[0].text = clueDescription[1];             

                    clue1Clicked = true;

                    Image myClue1Image = myClue1.GetComponent<Image>();
                    myClue1Image.sprite = clueImage[1];
                    showClueDetails.SetActive(true);
                }
                if(selectedObject.tag=="Clue2")  
                {
                    Debug.Log("이름은 : "+clueName[2] + "설명 : "+clueDescription[2]);



                    //clue의 패널 ui 상 이미지와 설명을 바꾸는 코드  
                    Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
                    imageComponents[1].sprite =  clueImage[2];       

                    TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
                    textComponents[0].text = clueDescription[2];   

                    clue2Clicked = true;

                    Image myClue2Image = myClue2.GetComponent<Image>();
                    myClue2Image.sprite = clueImage[2];  
                    showClueDetails.SetActive(true);        

                }
                if(selectedObject.tag=="Clue3")  
                {
                    useClue3.gameObject.SetActive(true);

                    Debug.Log("이름은 : "+clueName[3] + "설명 : "+clueDescription[3]);



                    //clue의 패널 ui 상 이미지와 설명을 바꾸는 코드  
                    Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
                    imageComponents[1].sprite =  clueImage[3];       

                    TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
                    textComponents[0].text = clueDescription[3];   

                    clue3Clicked = true;

                    Image myClue3Image = myClue3.GetComponent<Image>();
                    myClue3Image.sprite = clueImage[3];   
                    showClueDetails.SetActive(true);       

                }
                if(selectedObject.tag=="Clue4")  
                {
                    Debug.Log("이름은 : "+clueName[4] + "설명 : "+clueDescription[4]);



                    //clue의 패널 ui 상 이미지와 설명을 바꾸는 코드  
                    Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
                    imageComponents[1].sprite =  clueImage[4];       

                    TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
                    textComponents[0].text = clueDescription[4];   

                    clue4Clicked = true;

                    Image myClue4Image = myClue4.GetComponent<Image>();
                    myClue4Image.sprite = clueImage[4];  
                    showClueDetails.SetActive(true);        

                }
                if(selectedObject.tag=="Clue0-2") 
                {
                    Debug.Log("이름은 : "+clueName[5] + "설명 : "+clueDescription[5]);



                    //clue의 패널 ui 상 이미지와 설명을 바꾸는 코드  
                    Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
                    imageComponents[1].sprite =  clueImage[5];       

                    TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
                    textComponents[0].text = clueDescription[5];        

                    showClueDetails.SetActive(true);
                    layer_main.SetActive(false);

                }
                if(selectedObject.tag=="Clue1-2") 
                {
                    Debug.Log("이름은 : "+clueName[6] + "설명 : "+clueDescription[6]);



                    //clue의 패널 ui 상 이미지와 설명을 바꾸는 코드  
                    Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
                    imageComponents[1].sprite =  clueImage[6];       

                    TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
                    textComponents[0].text = clueDescription[6];        

                    showClueDetails.SetActive(true);
                    layer_main.SetActive(false);

                }
                if(selectedObject.tag=="Clue1-3") 
                {
                    Debug.Log("이름은 : "+clueName[7] + "설명 : "+clueDescription[7]);



                    //clue의 패널 ui 상 이미지와 설명을 바꾸는 코드  
                    Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
                    imageComponents[1].sprite =  clueImage[7];       

                    TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
                    textComponents[0].text = clueDescription[7];        

                    showClueDetails.SetActive(true);
                    layer_main.SetActive(false);

                }


            }
        }
    }


    public void CallClue1Details()
    {   
        if(clue1Clicked == true)
        {

    
            Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
            imageComponents[1].sprite =  clueImage[1];       //imageComponents[0].sprite   은 레이어 순서에따라 Background로 되어있음. imageComponents[1]이 단서 사진 나오는 곳

            TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
            textComponents[0].text = clueDescription[1]; 


            Layer2.gameObject.SetActive(false);    
            showClueDetails.SetActive(true);


        }


    }
    public void CallClue2Details()
    {   
        if(clue2Clicked == true)
        {

    
            Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
            imageComponents[1].sprite =  clueImage[2];       //imageComponents[0].sprite   은 레이어 순서에따라 Background로 되어있음. imageComponents[1]이 단서 사진 나오는 곳

            TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
            textComponents[0].text = clueDescription[2]; 

            Layer2.gameObject.SetActive(false);    
            showClueDetails.SetActive(true);


        }


    }
    public void CallClue3Details()
    {   
        if(clue3Clicked == true)
        {
            


            Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
            imageComponents[1].sprite =  clueImage[3];       //imageComponents[0].sprite   은 레이어 순서에따라 Background로 되어있음. imageComponents[1]이 단서 사진 나오는 곳

            TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
            textComponents[0].text = clueDescription[3]; 

            Layer2.gameObject.SetActive(false);    
            showClueDetails.SetActive(true);


        }


    }
    public void CallClue4Details()
    {   
        if(clue4Clicked == true)
        {

    
            Image[] imageComponents = showClueDetails.GetComponentsInChildren<Image>();
            imageComponents[1].sprite =  clueImage[4];       //imageComponents[0].sprite   은 레이어 순서에따라 Background로 되어있음. imageComponents[1]이 단서 사진 나오는 곳

            TextMeshProUGUI[] textComponents = showClueDetails.GetComponentsInChildren<TextMeshProUGUI>();
            textComponents[0].text = clueDescription[4]; 

            Layer2.gameObject.SetActive(false);    
            showClueDetails.SetActive(true);


        }


    }
    











    public void ClickedBackBTNinshowClueDetails()
    {
        showClueDetails.SetActive(false);
    }


























    public float totalMinutes = 300.0f;
    public TextMeshProUGUI timerText;
    private bool timerOn ;

   
    private void UpdateTimer()
    {   
         
        if(timerOn == true)
        {
            totalMinutes -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(totalMinutes / 60);
            int seconds = Mathf.FloorToInt(totalMinutes % 60);

            timerText.text = "남은 시간: " + minutes.ToString("D2") + "분 " + seconds.ToString("D2") + "초";
        }

        if(totalMinutes<=0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        txt_escapemessage.SetActive(false);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        timerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        UpdateTimer();

    }
}
