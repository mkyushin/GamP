using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenes : MonoBehaviour
{
    public Button start;

    public void Gamestart()
    {
        SceneManager.LoadScene("MainScene");
    }
    private void OnTriggerEnter(Collider finish)
    {
        // 특정 태그를 가진 오브젝트가 게임 종료 영역에 진입했는지 확인
        if (finish.CompareTag("Player"))
        {
            Debug.Log("finsh");
            // 게임 종료 씬으로 전환
            SceneManager.LoadScene("GameFinish");
        }
    }











    public void GameFinish()
    {
        SceneManager.LoadScene("GameFinish");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
