using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionBoard : MonoBehaviour
{
    public TMP_Text QuestionText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateQuestion(string text)
    {
        QuestionText.text = text;
    }
}
