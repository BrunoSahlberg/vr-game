using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float scaleY = 3f;
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{Time.realtimeSinceStartup}alguma coisa
    }

    public void Undistort()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void Distort()
    {
        transform.localScale = new Vector3(1, scaleY, 1);
    }
}
