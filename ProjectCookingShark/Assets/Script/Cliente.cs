using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    int pontuacao = 0;
    
    public int sortearNumero;

    [SerializeField] public ListaDePedidos listaDePedidos;

    public Pedido pedidoDoCliente;

    public Receita pratoRecebido;

    public Prato.IngredientePremium ingredientePremium;

    public Ingrediente saborPremiumIngrediente;

    private bool primeiroIngrediente = false;

    private bool segundoIngrediente = false;

    private bool terceiroIngrediente = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IngredientePremiumParaOCliente();
    }

    private void IngredientePremiumParaOCliente()
    {
        if (pratoRecebido != null)
        {
            if (ingredientePremium == Prato.IngredientePremium.PrimeiroIngredientePremium)
            {
                saborPremiumIngrediente = pratoRecebido.ingredientes01;
            }
            else if (ingredientePremium == Prato.IngredientePremium.SegundoIngredientePremium)
            {
                saborPremiumIngrediente = pratoRecebido.ingredientes01;
            }
            else if (ingredientePremium == Prato.IngredientePremium.SemIngredientePremium)
            {
                saborPremiumIngrediente = null;
            }
        }
    }

    public void Pontuacao()
    {
        if (pedidoDoCliente.IngredienteProibidoPedido.NomeDoIngrediente != pratoRecebido.ingredientes01.NomeDoIngrediente &&
           pedidoDoCliente.IngredienteProibidoPedido.NomeDoIngrediente != pratoRecebido.ingredientes02.NomeDoIngrediente)
        {
            Debug.Log(pontuacao);

            if (pedidoDoCliente != null)
            {
                if(primeiroIngrediente != false) { 
                    if (pratoRecebido.ingredientes01.Sabor == pedidoDoCliente.SaborPedido01)
                    {
                        pontuacao += 100;
                        primeiroIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                    else if (pratoRecebido.ingredientes02.Sabor == pedidoDoCliente.SaborPedido01)
                    {
                        pontuacao += 100;
                        primeiroIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                }
                if (segundoIngrediente != false)
                {
                    if (pratoRecebido.ingredientes01.Sabor == pedidoDoCliente.SaborPedido02)
                    {
                        pontuacao += 100;
                        segundoIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                    else if (pratoRecebido.ingredientes02.Sabor == pedidoDoCliente.SaborPedido02)
                    {
                        pontuacao += 100;
                        segundoIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                }
                if (terceiroIngrediente != false && saborPremiumIngrediente != null)
                {
                    if(saborPremiumIngrediente.Sabor == pedidoDoCliente.saborPedido03)
                    {
                        pontuacao += 100;
                        terceiroIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                    else if(saborPremiumIngrediente.Sabor == pedidoDoCliente.saborPedido03)
                    {
                        pontuacao += 100;
                        terceiroIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                }
            }
        
        }
    }

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
