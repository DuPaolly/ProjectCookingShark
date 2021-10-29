using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    public int sortearNumero;

    [SerializeField] public ListaDePedidos listaDePedidos;

    public Pedido pedidoDoCliente;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void PedidoAtualDesteCliente()
    //{
    //    pedidoAtual = listaDePedidos.SortearPedidoDoCliente();

    //    Debug.Log(pedidoAtual.SaborPedido01);
    //    Debug.Log(pedidoAtual.SaborPedido02);
    //    Debug.Log(pedidoAtual.IngredienteProibidoPedido);
    //    Debug.Log("Ingrediente premium: " + pedidoAtual.saborPedido03);
    //}

    public void SortearPedidoDoCliente()
    {
        sortearNumero = SortearNumero();

        pedidoDoCliente = listaDePedidos.pedidosPossiveis[sortearNumero];

        if (pedidoDoCliente.PremiumIngredienteDoCliente == Pedido.IngredientePremiumDoClente.PrimeiroIngredientePremium)
        {
            pedidoDoCliente.saborPedido03 = pedidoDoCliente.SaborPedido01;
        }
        else if (pedidoDoCliente.PremiumIngredienteDoCliente == Pedido.IngredientePremiumDoClente.SegundoIngredientePremium)
        {
            pedidoDoCliente.saborPedido03 = pedidoDoCliente.SaborPedido02;
        }
        else
        {
            pedidoDoCliente.saborPedido03 = Sabores.SaboresExistentes.nenhum;
        }

        Debug.Log(pedidoDoCliente.SaborPedido01);
        Debug.Log(pedidoDoCliente.SaborPedido02);
        Debug.Log(pedidoDoCliente.IngredienteProibidoPedido);
        Debug.Log(pedidoDoCliente.saborPedido03);
    }

    public int SortearNumero()
    {
        return Random.Range(0, listaDePedidos.pedidosPossiveis.Length);
    }

}
