using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStatic : MonoBehaviour
{

    float CurrentPositionX;
    float CurrentPositionY;
    float CurrentPositionZ;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPositionX = transform.localPosition.x;
        CurrentPositionY = transform.localPosition.y;
        CurrentPositionZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.localPosition);
    }

    public void AdjustPush()
    {
        transform.localPosition = new Vector3(CurrentPositionX, CurrentPositionY + 6.5f, CurrentPositionZ);
    }

    public void AdjustIdle()
    {
        transform.localPosition = new Vector3(CurrentPositionX, CurrentPositionY, CurrentPositionZ);
    }
}
