using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public string[] m_Questions;   // list of questions
    public string[] m_CorrectAnswers;   // list of correct answers (same order)

    public Text m_QuestionText;  // the current question being shown when in the user interfarce 

    private int m_CurrentQuestion = 0;   // what question wer'er on 

    // Start is called before the first frame update
    void Start()
    {
        ShowQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ShowQuestion()
    {
        if (m_CurrentQuestion < m_Questions.Length)
        {
            m_QuestionText.text = m_Questions[m_CurrentQuestion];
        }
        else
        {
            m_QuestionText.text = "All questions complete";
        }
    }
    public bool CheckAnswer(string chosenAnwer)
    {
        if (m_CurrentQuestion >= m_CorrectAnswers.Length)
        {
            return false;
        }
        // compare chosen answer with the correct one
        if (chosenAnwer == m_CorrectAnswers[m_CurrentQuestion])
        {
            Debug.Log("Correct!");
            m_CurrentQuestion++;
            ShowQuestion();
            return true;
        }
        else
        {
            Debug.Log("Wrong");
            return false;
         }
    }
}
