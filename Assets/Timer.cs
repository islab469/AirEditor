using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int m_seconds;

    public int m_min;
    public int m_sec;

    public Text m_timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
      
    }

    IEnumerator Countdown()
    {
        m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        m_seconds = (m_min * 60) + m_sec;       //將時間換算為秒數

        while (m_seconds > 0)                   //如果時間尚未結束
        {
            yield return new WaitForSeconds(1); //等候一秒再次執行

            m_seconds--;                        //總秒數減 1
            m_sec--;                            //將秒數減 1

            if (m_sec < 0 && m_min > 0)         //如果秒數為 0 且分鐘大於 0
            {
                m_min -= 1;                     //先將分鐘減去 1
                m_sec = 59;                     //再將秒數設為 59
            }
            else if (m_sec < 0 && m_min == 0)   //如果秒數為 0 且分鐘大於 0
            {
                m_sec = 0;                      //設定秒數等於 0
            }
            m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00")); //顯示當前秒數
        }

        yield return new WaitForSeconds(2);   //時間結束時，顯示 00:00 停留2秒
        Time.timeScale = 0;                   //時間結束時，控制遊戲暫停無法操作
       
    }
    private void Update()
    {
         if (m_seconds==0)
        {
            SceneManager.LoadScene("gameover");
            
        }
    }


}
