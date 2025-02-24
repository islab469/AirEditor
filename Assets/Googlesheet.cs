using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Googlesheet : MonoBehaviour
{
    string DateTimeNow = DateTime.Now.ToString();
    //public GameObject uri_text;
    public GameObject school1;
    public GameObject school2;
    public GameObject school3;
    public GameObject school4;
    public GameObject Name1;
    public GameObject Name2;
    public GameObject Name3;
    public GameObject Name4;
    public GameObject Class1;
    public GameObject Class2;
    public GameObject Class3; 
    public GameObject Class4;
    public GameObject Sex1;
    public GameObject Sex2;
    public GameObject Sex3;
    public GameObject Sex4;
    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject Number4;

    public GameObject Ans_Y_1;      //���a1�����ﶵ��
    public GameObject Ans_Y_2;
    public GameObject Ans_Y_3;
    public GameObject Ans_Y_4;
    public GameObject Ans_N_1;      //���a1����������
    public GameObject Ans_N_2;
    public GameObject Ans_N_3;
    public GameObject Ans_N_4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Upload());
    }
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "write");

        form.AddField("date_0", "   ");
        form.AddField("school_0", "   ");
        form.AddField("class_0", "     ");
        form.AddField("id_0", "     ");
        form.AddField("num_0", "     ");
        form.AddField("sex_0", "     ");
        form.AddField("correct_0", "        ");
        form.AddField("wrong_0", "      ");

        form.AddField("date", DateTimeNow);
        form.AddField("school_1", school1.GetComponent<Text>().text);
        form.AddField("class_1",Class1.GetComponent<InputField>().text);
        form.AddField("id_1", Name1.GetComponent<InputField>().text);
        form.AddField("num_1", Number1.GetComponent<InputField>().text);
        form.AddField("sex_1", Sex1.GetComponent<Text>().text);
        form.AddField("correct_1", Ans_Y_1.GetComponent<Text>().text);
        form.AddField("wrong_1", Ans_N_1.GetComponent<Text>().text);

        form.AddField("school_2", school2.GetComponent<Text>().text);
        form.AddField("class_2", Class2.GetComponent<InputField>().text);
        form.AddField("id_2", Name2.GetComponent<InputField>().text);
        form.AddField("num_2", Number2.GetComponent<InputField>().text);
        form.AddField("sex_2", Sex2.GetComponent<Text>().text);
        form.AddField("correct_2", Ans_Y_2.GetComponent<Text>().text);
        form.AddField("wrong_2", Ans_N_2.GetComponent<Text>().text);

        form.AddField("school_3", school3.GetComponent<Text>().text);
        form.AddField("class_3", Class3.GetComponent<InputField>().text);
        form.AddField("id_3", Name3.GetComponent<InputField>().text);
        form.AddField("num_3", Number3.GetComponent<InputField>().text);
        form.AddField("sex_3", Sex3.GetComponent<Text>().text);
        form.AddField("correct_3", Ans_Y_3.GetComponent<Text>().text);
        form.AddField("wrong_3", Ans_N_3.GetComponent<Text>().text);

        form.AddField("school_4", school4.GetComponent<Text>().text);
        form.AddField("class_4", Class4.GetComponent<InputField>().text);
        form.AddField("id_4", Name4.GetComponent<InputField>().text);
        form.AddField("num_4", Number4.GetComponent<InputField>().text);
        form.AddField("sex_4", Sex4.GetComponent<Text>().text);
        form.AddField("correct_4", Ans_Y_4.GetComponent<Text>().text);
        form.AddField("wrong_4", Ans_N_4.GetComponent<Text>().text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbxiPd7lACb9GPeSnhDwPHQtrLXTfCouiHSVkAn3BA3WbWtP4GJeNBSku071OrM1NV4O/exec", form))//uri_text.GetComponent<Text>().text
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
