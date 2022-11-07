using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    public GameObject Arrow;
    public MeshRenderer ProjectileMesh;
    public float velocity = 1f;

    void Start()
    {
        ProjectileMesh.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 position, Quaternion rotation)
    {
        GameObject cA = Instantiate(Arrow, position, rotation);
        Rigidbody rig = cA.GetComponent<Rigidbody>();

        rig.AddForce(transform.up * velocity, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("teste");
        Rigidbody rig = Arrow.GetComponent<Rigidbody>();
        rig.velocity = Vector3.zero;
    }
}
