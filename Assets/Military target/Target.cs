using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int answer;
    public bool IsDisabled;
    public bool isRightTarget = false;
    public GameManager GameManager;

    private void Awake()
    {

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
