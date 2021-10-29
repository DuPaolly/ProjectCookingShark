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

    [SerializeField] public MiniGameManager.TipoMiniGame minigame;

    int smoothVelocidade = 20;

    private bool podeVoltar;

    private Vector3 _originalPosition;

    private bool _dragging;

    private Vector2 offset, _posicaoAtual;

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
    private void FixedUpdate()
    {
        VolteParaPosicao();
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
                podeVoltar = PodeVoltarAPosiçãoInicial();
            }
            else
            {
                AdicionarOIngredienteAoPrato();
                MiniGameManager.IniciaMiniGame(minigame);
                //Start Minigame
                podeVoltar = JaChegouNoDestino();
            }
        }
        else
        {
           podeVoltar = PodeVoltarAPosiçãoInicial();
        }
    }

    private void VolteParaPosicao()
    {
        if (podeVoltar)
        {
            _posicaoAtual = transform.position;

            _posicaoAtual = Vector3.Lerp(
                transform.position,
                _originalPosition,
                smoothVelocidade * Time.deltaTime);

            transform.position = _posicaoAtual;

        }
        else if(transform.position == _originalPosition)
        {
            podeVoltar = JaChegouNoDestino();
        }
        
    }

    private bool PodeVoltarAPosiçãoInicial()
    {
        return true;
        //transform.position = _originalPosition;
    }

    private bool JaChegouNoDestino()
    {
        return false;
    }

    private void MouseDragUpdate()
    {
        podeVoltar = JaChegouNoDestino();
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
