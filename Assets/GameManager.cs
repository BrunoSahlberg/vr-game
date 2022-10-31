using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform Objeto;
    public string Nome;
    public int Numero;
    public float LeFloat;
    public Bow Arco;
    public MeshRenderer Meshi;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        var arco = Meshi.gameObject.GetComponent<Bow>();
        Debug.Log($"obj {arco.name} filho de {arco.transform.parent.name}");
    }

    // Update is called once per frame
    void Update()
    {
        bool IsPressingF = Input.GetKey(KeyCode.F);

        if (IsPressingF) Arco.Distort();
        else Arco.Undistort();
         
        
    }
}
