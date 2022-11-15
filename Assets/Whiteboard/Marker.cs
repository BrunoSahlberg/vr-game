using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Marker : MonoBehaviour
{
    [SerializeField] private Transform Tip;
    [SerializeField] private int PenSize = 5;

    private Renderer _renderer;
    private Color[] _colors;
    private float _tipHeight;

    private RaycastHit _touch;
    private Whiteboard _whiteboard;
    private Vector2 _touchPos;
    private bool _touchedLastFrame;
    private Vector2 _lastTouchPos;
    private Quaternion _lastTouchRot;

    void Start()
    {
        _renderer = Tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, PenSize * PenSize).ToArray();
        _tipHeight = Tip.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Physics.Raycast(Tip.position, transform.up, out _touch, _tipHeight))
        {
            if (_touch.transform.CompareTag("Whiteboard"))
            {
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touchPos.x * _whiteboard.textrueSize.x - (PenSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textrueSize.y - (PenSize / 2));

                if (y < 0 || y > _whiteboard.textrueSize.y || x < 0 || x > _whiteboard.textrueSize.x) return;

                if (_touchedLastFrame)
                {
                    _whiteboard.texture.SetPixels(x, y, PenSize, PenSize, _colors);

                    for (float f = 0.01f; f < 1.00f; f += 0.10f)
                    {
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpy = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpX, lerpy, PenSize, PenSize, _colors);

                    }

                    transform.rotation = _lastTouchRot;

                    _whiteboard.texture.Apply();
                }

                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }

        _whiteboard = null;
        _touchedLastFrame = false;
    }
}
