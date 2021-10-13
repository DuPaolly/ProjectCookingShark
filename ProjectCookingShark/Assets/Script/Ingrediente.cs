using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : Sabores
{
    [SerializeField] string nome;
    public string Nome => nome;
    [SerializeField] Sabores.SaboresExistentes sabor;
    public Sabores.SaboresExistentes Sabor => sabor;

    private Vector2 _offset, _originalPosition;

    private bool _dragging;

    private void Awake()
    {
        _originalPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseUp()
    {
        if ( == )
        {
            Debug.Log("deu");
        }

        transform.position = _originalPosition;
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }


}
