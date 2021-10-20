using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : Sabores
{
    private Prato pratoEmProducao;

    [SerializeField] string nomeDoIngrediente;
    public string NomeDoIngrediente => nomeDoIngrediente;
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

    private void OnTriggerEnter2D(Collider2D areaEmQueEncostou)
    {
        Prato pratoEncontrado = areaEmQueEncostou.GetComponent<Prato>();

        if(pratoEncontrado != null)
        {
            pratoEmProducao = pratoEncontrado;
        }
    }

    private void OnTriggerExit2D(Collider2D areaEmQueSaiu)
    {
        Prato pratoQuePerdeu = areaEmQueSaiu.GetComponent<Prato>();

        if(pratoQuePerdeu != null)
        {
            pratoEmProducao = null;
        }
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    private void MouseDropObject()
    {
        if(pratoEmProducao != null)
        {
            if (!pratoEmProducao.PodeReceberIngrediente(this))
            {
                VoltaAPosiçãoInicial();
            }
            else
            {
                AdicionarOIngredienteAoPrato();            
            }
        }
        else
        {
            VoltaAPosiçãoInicial();
        }
    }

    private void VoltaAPosiçãoInicial()
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

    void AdicionarOIngredienteAoPrato()
    {
        transform.position = pratoEmProducao.transform.position;
        transform.SetParent(pratoEmProducao.transform);
    }

}
