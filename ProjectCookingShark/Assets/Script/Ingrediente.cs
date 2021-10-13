using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : Sabores
{

    object obj;
    obj = Collider2D;

    [SerializeField] string nome;
    public string Nome => nome;
    [SerializeField] Sabores.SaboresExistentes sabor;
    public Sabores.SaboresExistentes Sabor => sabor;

    private Vector2 _offset, _originalPosition;

    private bool _dragging;

    private void Awake()
    {
        ObjectStart();
    }

    private void OnMouseDrag()
    {
        MouseDragUpdate();
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseUp()
    {
        MouseDropObject();
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    private void MouseDropObject()
    {
        transform.position = _originalPosition;
    }
    private void MouseDragUpdate()
    {
        transform.position = GetMousePos();
    }

    private void ObjectStart()
    {
        _originalPosition = transform.position;
    }


}
