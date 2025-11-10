using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour  
{
    public string m_AnwerText; // what this object represent
    public Text m_WorldText;

    private QuestionManager m_QuestionManagerRef;

    // Start is called before the first frame update
    void Start()
    {
        m_QuestionManagerRef =  FindObjectOfType<QuestionManager>();

        if(m_WorldText != null)
        {
            m_WorldText.text = m_AnwerText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bool correct = m_QuestionManagerRef.CheckAnswer(m_AnwerText);

            if (correct)
            {
                Debug.Log("Player chose the right answer");
                // could rewrard the player with points or open a dorr 
            }
            else
            {
                Debug.Log("Player chose the wrong answer");
                // could rducuce the player health
            }
        }
    }
}
