using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PratoCliente : MonoBehaviour
{
    public Receita pratoServido;

    private Cliente cliente;

    public Prato.IngredientePremium premiumIngrediente;

    private Vector3 _originalPosition;

    private Vector2 offset, _posicaoAtual;

    int smoothVelocidade = 20;

    private void Awake()
    {
        ObjectStart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        VolteParaPosicao();
    }

    private void OnTriggerEnter2D(Collider2D areaEmQueEncostou)
    {
        Cliente clienteAchado = areaEmQueEncostou.GetComponent<Cliente>();

        if (clienteAchado != null)
        {
            cliente = clienteAchado;
        }
    }

    private void OnTriggerExit2D(Collider2D areaEmQueSaiu)
    {
        Cliente clienteAchado = areaEmQueSaiu.GetComponent<Cliente>();

        if (clienteAchado != null)
        {
            cliente = null;
        }
    }

    private void OnMouseDrag()
    {
        MouseDragUpdate();
    }
    private void OnMouseUp()
    {
        VolteParaPosicao();
        MouseDropObject();
    }

    private void ObjectStart()
    {
        _originalPosition = transform.position;
    }

    private void MouseDragUpdate()
    {
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

        _posicaoAtual = transform.position;

        _posicaoAtual = Vector3.Lerp(
            transform.position,
            _originalPosition,
            smoothVelocidade * Time.deltaTime);

        transform.position = _posicaoAtual;

    }

    private void MouseDropObject()
    {
        if (cliente != null)
        {
            cliente.ingredientePremium = premiumIngrediente;
            cliente.pratoRecebido = pratoServido;       

            DescartaPrato();
        }
    }

    public void DescartaPrato()
    {
        premiumIngrediente = Prato.IngredientePremium.SemIngredientePremium;
        pratoServido = null;
    }
}
