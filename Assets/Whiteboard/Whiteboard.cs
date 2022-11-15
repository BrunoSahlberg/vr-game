using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textrueSize = new Vector2(2048, 2048);

    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)textrueSize.x, (int)textrueSize.y);
        r.material.mainTexture = texture;
    }
}
