using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalMinutes = 5.0f;
    private float currentTime;
    public TextMeshProUGUI timerText;

    private void timeSet()
    {
        currentTime = totalMinutes * 60;
        UpdateTimer();
    }    


    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = "남은 시간: " + minutes.ToString("D2") + "분 " + seconds.ToString("D2") + "초";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime >= 0)
        {
            //UpdateTimer();
        }
    }


}
