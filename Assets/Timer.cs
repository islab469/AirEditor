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
        m_seconds = (m_min * 60) + m_sec;       //�N�ɶ����⬰���

        while (m_seconds > 0)                   //�p�G�ɶ��|������
        {
            yield return new WaitForSeconds(1); //���Ԥ@��A������

            m_seconds--;                        //�`��ƴ� 1
            m_sec--;                            //�N��ƴ� 1

            if (m_sec < 0 && m_min > 0)         //�p�G��Ƭ� 0 �B�����j�� 0
            {
                m_min -= 1;                     //���N������h 1
                m_sec = 59;                     //�A�N��Ƴ]�� 59
            }
            else if (m_sec < 0 && m_min == 0)   //�p�G��Ƭ� 0 �B�����j�� 0
            {
                m_sec = 0;                      //�]�w��Ƶ��� 0
            }
            m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00")); //��ܷ�e���
        }

        yield return new WaitForSeconds(2);   //�ɶ������ɡA��� 00:00 ���d2��
        Time.timeScale = 0;                   //�ɶ������ɡA����C���Ȱ��L�k�ާ@
       
    }
    private void Update()
    {
         if (m_seconds==0)
        {
            SceneManager.LoadScene("gameover");
            
        }
    }


}
