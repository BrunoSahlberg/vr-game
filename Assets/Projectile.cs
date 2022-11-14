using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Quaternion initialRotation;
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO maybe~: Realitic arrow parabole
        // transform.rotation = Quaternion.LookRotation(rigid.velocity) * initialRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rig = this.GetComponent<Rigidbody>();
        rig.velocity = Vector3.zero;
        rig.useGravity = false;
        rig.isKinematic = true;
    }
}
