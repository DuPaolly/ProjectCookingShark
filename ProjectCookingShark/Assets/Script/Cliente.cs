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

    public Frigideira.IngredientePremium ingredientePremium;

    public Ingrediente saborPremiumIngrediente;

    private bool primeiroIngrediente = false;

    private bool segundoIngrediente = false;

    private bool terceiroIngrediente = false;

    void Start()
    {
        SortearPedidoDoCliente();
    }
    void FixedUpdate()
    {
        IngredientePremiumParaOCliente();
    }

    private void IngredientePremiumParaOCliente()
    {
        if (pratoRecebido != null)
        {
            if (ingredientePremium == Frigideira.IngredientePremium.PrimeiroIngredientePremium)
            {
                saborPremiumIngrediente = pratoRecebido.ingredientes01;
            }
            else if (ingredientePremium == Frigideira.IngredientePremium.SegundoIngredientePremium)
            {
                saborPremiumIngrediente = pratoRecebido.ingredientes02;
            }
            else if (ingredientePremium == Frigideira.IngredientePremium.SemIngredientePremium)
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
            Debug.Log(pratoRecebido.NomePrato);

            if (pratoRecebido != null)
            {
                Debug.Log(pontuacao);

                if (primeiroIngrediente == false)
                {
                    Debug.Log(pontuacao);

                    if (pratoRecebido.ingredientes01.Sabor.Equals(pedidoDoCliente.SaborPedido01))
                    {
                        pontuacao += 100;
                        primeiroIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                    else if (pratoRecebido.ingredientes02.Sabor.Equals(pedidoDoCliente.SaborPedido01))
                    {
                        pontuacao += 100;
                        primeiroIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                }
                if (segundoIngrediente == false)
                {
                    if (pratoRecebido.ingredientes01.Sabor.Equals(pedidoDoCliente.SaborPedido02))
                    {
                        pontuacao += 100;
                        segundoIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                    else if (pratoRecebido.ingredientes02.Sabor.Equals(pedidoDoCliente.SaborPedido02))
                    {
                        pontuacao += 100;
                        segundoIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                }
                if (terceiroIngrediente == false && saborPremiumIngrediente != null)
                {
                    Debug.Log(saborPremiumIngrediente.Sabor);
                    Debug.Log(pedidoDoCliente.saborPedido03);

                    if (saborPremiumIngrediente.Sabor.Equals(pedidoDoCliente.saborPedido03))
                    {
                        pontuacao += 100;
                        terceiroIngrediente = true;
                        Debug.Log(pontuacao);

                    }
                    else if (saborPremiumIngrediente.Sabor.Equals(pedidoDoCliente.saborPedido03))
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
