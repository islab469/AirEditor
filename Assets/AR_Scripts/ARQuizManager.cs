using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ARQuizManager : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Question
    {
        public string questionText; // 題目文字
        public string[] answers; // 選項文字
        public int correctAnswerIndex; // 正確答案索引
    }

    public GameObject questionTextObject; // 顯示題目的 3D TextMeshPro
    public GameObject[] answerOptionObjects; // 答案選項的 3D 按鈕物件（平面或立方體）
    public Question[] questions; // 題目列表

    private int currentQuestionIndex = 0;

    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (questions == null || questions.Length == 0)
        {
            Debug.LogError("No questions available.");
            return;
        }

        TextMeshPro questionTextMesh = questionTextObject.GetComponent<TextMeshPro>();
        if (questionTextMesh != null)
        {
            questionTextMesh.text = questions[currentQuestionIndex].questionText;
        }

        Question question = questions[currentQuestionIndex];
        for (int i = 0; i < answerOptionObjects.Length; i++)
        {
            if (i < question.answers.Length)
            {
                TextMeshPro optionTextMesh = answerOptionObjects[i].GetComponentInChildren<TextMeshPro>();
                if (optionTextMesh != null)
                {
                    optionTextMesh.text = question.answers[i];
                }

                int index = i; // 防止閉包問題
                answerOptionObjects[i].GetComponent<Collider>().enabled = true;
                answerOptionObjects[i].GetComponent<AnswerButton>().Setup(() => CheckAnswer(index));
            }
            else
            {
                answerOptionObjects[i].SetActive(false);
            }
        }

    }

    void CheckAnswer(int index)
    {
        if (index == questions[currentQuestionIndex].correctAnswerIndex)
        {
            Debug.Log("答案正確！");
        }
        else
        {
            Debug.Log("答案錯誤！");
        }

        // 顯示下一題
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            Debug.Log("所有題目已完成！");
        }
    }

}
