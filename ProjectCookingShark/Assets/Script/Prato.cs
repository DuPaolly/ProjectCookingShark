using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Prato : Receita
{
    private PratoCliente pratoDoCliente;

    public Receita receitaAtual;

    private bool podeVoltar;

    private Vector3 _originalPosition;

    private Vector2 offset, _posicaoAtual;

    int smoothVelocidade = 20;

    Ingrediente saborPremiumIngrediente;

    [SerializeField] IngredientePremium premiumIngredientes;
    public IngredientePremium PremiumIngredientes => premiumIngredientes;

    [SerializeField] CheckerPrato inventarioDeReceita;

    public enum IngredientePremium
    {
        SemIngredientePremium,
        PrimeiroIngredientePremium,
        SegundoIngredientePremium
    }
    private void Awake()
    {
        ObjectStart();
    }

    private void FixedUpdate()
    {
        VolteParaPosicao();
        ingredientePremium();
    }
    private void OnMouseDrag()
    {
        MouseDragUpdate();
    }
    private void OnMouseUp()
    {
        MouseDropObject();
    }

    void ingredientePremium()
    {
        if (premiumIngredientes == IngredientePremium.PrimeiroIngredientePremium)
        {
            saborPremiumIngrediente = ingredientes01;
            //Debug.Log("estao iguais manolos");
        }
        else if (premiumIngredientes == IngredientePremium.SegundoIngredientePremium)
        {
            saborPremiumIngrediente = ingredientes02;
            //Debug.Log("estao iguais manolos, mas ao segundo");
        }
        else
        {
            //Debug.Log("Tem ninguem aqui nao");
            saborPremiumIngrediente = null;
        }
    }
    
    public bool PodeReceberIngrediente(Ingrediente ingredienteParaAdicionar)
    {
        if(ingredientes01 == null && ingredientes02 == null)
        {
            ingredientes01 = ingredienteParaAdicionar;
            return true;
        }
        else if(ingredientes01 != null && ingredientes02 != null)
        {
            return false;
        }
        else
        {
            if (ingredientes01 != null)
            {
                if (ingredientes01.NomeDoIngrediente.Equals(ingredienteParaAdicionar.NomeDoIngrediente))
                {
                    Debug.Log("tao iguais mano");
                    return false;
                }
                else
                {
                    ingredientes02 = ingredienteParaAdicionar;
                    return true;
                }
            }
            else
            {
                if (ingredientes02.NomeDoIngrediente.Equals(ingredienteParaAdicionar.NomeDoIngrediente  ))
                {
                    return false;
                }
                else
                {
                    ingredientes01 = ingredienteParaAdicionar;
                    return true;
                }
            }
        }
    }

    public void DescartaIngrediente()
    {
        inventarioDeReceita.id = 0;
        if (ingredientes01 != null)
        {
            Destroy(ingredientes01.gameObject);
            ingredientes01 = null;
            inventarioDeReceita.ingrediente1Achado = false;
        }
        if (ingredientes02 != null)
        {
            Destroy(ingredientes02.gameObject);
            ingredientes02 = null;
            inventarioDeReceita.ingrediente2Achado = false;
        }
        premiumIngredientes = IngredientePremium.SemIngredientePremium;
        receitaAtual = null;
    }
    private void ObjectStart()
    {
        _originalPosition = transform.position;
    }

    private void MouseDropObject()
    {
        if (pratoDoCliente != null)
        {
            if (false)
            {
                podeVoltar = PodeVoltarAPosiçãoInicial();
            }
            else
            {
                //AdicionarOIngredienteAoPrato();
                //Start Minigame
                podeVoltar = JaChegouNoDestino();
            }
        }
        else
        {
            podeVoltar = PodeVoltarAPosiçãoInicial();
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
    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
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
        else if (transform.position == _originalPosition)
        {
            podeVoltar = JaChegouNoDestino();
        }

    }
}
