using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public int answer;
    public bool IsDisabled;
    public bool isRightTarget = false;
    public GameManager GameManager;
    public TMP_Text AnswerText;

    private void Update()
    {
        AnswerText.text = answer.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsDisabled) { 
            if (isRightTarget)
            {
                GameManager.RightAnswer();
            }
            else
            {
                // TO DO: negative points
                GameManager.WrongAnswer();

            }
        }
    }
}
