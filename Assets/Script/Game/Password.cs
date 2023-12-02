using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Password : MonoBehaviour
{
    public Transform player ; 
    public Transform doorlock;
    public GameObject door3;
    public GameObject door3Opened;





    public TextMeshProUGUI hint1;
    public TextMeshProUGUI hint2;
    public TextMeshProUGUI answerText ;
    public TextMeshProUGUI message1; 

    public GameObject layer_doorfinal;
    public GameObject layer_Main;  
    public GameObject doorLockNumpad ;


    public void Btn1Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "1";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }

    public void Btn2Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "2";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }
    public void Btn3Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "3";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }
    public void Btn4Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "4";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }
    public void Btn5Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "5";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }
    public void Btn6Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "6";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }
    public void Btn7Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "7";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }
    public void Btn8Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "8";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }
    public void Btn9Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "9";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }
    public void Btn0Click()
    {   
        if (answerText.text.Length < 4)
        {
            answerText.text = answerText.text + "0";
        }
        if(hint1.gameObject.activeSelf)
        {
            CheckPassword1();
        }
        if(hint2.gameObject.activeSelf)
        {
            CheckPassword2();
        }

    }



























    public void CheckPassword1()
    {
        if(answerText.text.Length == 4 && answerText.text == "2569")     //정답 2569
        {
            hint1.gameObject.SetActive(false);
            hint2.gameObject.SetActive(true);

            doorLockNumpad.SetActive(false);
            message1.gameObject.SetActive(true);
            StartCoroutine(DisableMessageAfterDelay(4.0f));

            answerText.text = "";
        }
        if(answerText.text.Length == 4 && answerText.text != "2569")
        {
            answerText.text ="틀렸습니다. 다시 입력하세요";
            StartCoroutine(ClearAnswerText(1.0f));
        } 
    }
    public void CheckPassword2()
    {
        if(hint2.gameObject.activeSelf)
        {
            if(answerText.text.Length == 4 && answerText.text == "7381")     //정답 7381
            {
                layer_doorfinal.SetActive(false);
                answerText.text = "";
                CorrectPassword();
                layer_Main.SetActive(true);
            }
            if(answerText.text.Length == 4 && answerText.text != "7381")
            {
                answerText.text ="틀렸습니다. 다시 입력하세요";
                StartCoroutine(ClearAnswerText(1.0f));
            }            

        }

    }









    public void EnterPassword()
    {   
        Vector3 playerLoc = player.position;
        Vector3 doorlockLoc = doorlock.position;

        float distanceToDoorlock = Vector3.Distance(playerLoc,doorlockLoc);

        if(distanceToDoorlock<= 7.0f)
        {

            layer_doorfinal.SetActive(true);
            layer_Main.SetActive(false);

        }

    }

    public void CorrectPassword()
    {
       door3.SetActive(false);
       door3Opened.SetActive(true);

    }

    private IEnumerator ClearAnswerText(float delay)
    {
        yield return new WaitForSeconds(delay);
        answerText.text = "";
    }
    private IEnumerator DisableMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        message1.gameObject.SetActive(false);
        doorLockNumpad.SetActive(true);
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClearAnswerText(1.0f);


        //도어락 ui띄우기 위한 코드
        if (Input.GetKeyDown(KeyCode.R) )
        {   
            Debug.Log("R pressed");

            EnterPassword();
        }
        
    }
}
