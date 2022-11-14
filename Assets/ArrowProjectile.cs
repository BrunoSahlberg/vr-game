using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TO DO: Refactor class name

public class ArrowProjectile : MonoBehaviour
{
    public Transform SpawnPoint;
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

    public void Shoot()
    {
        GameObject cA = Instantiate(Arrow, SpawnPoint.position, SpawnPoint.rotation);
        Rigidbody rig = cA.GetComponent<Rigidbody>();

        rig.AddForce(transform.up * velocity, ForceMode.Impulse);
    }
}
