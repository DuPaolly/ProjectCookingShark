using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    int pontuacao = 0;

    ClienteManager manager;

    public int sortearNumero;

    [SerializeField] public ListaDePedidos listaDePedidos;

    public Pedido pedidoDoCliente;

    public Receita pratoRecebido;

    public Frigideira.IngredientePremium ingredientePremium;

    public Ingrediente saborPremiumIngrediente;

    [SerializeField] public Positions[] posicoesDeEntradaESaida;

    [SerializeField] public Positions[] posicoesDosClientes;

    Positions mesaEscolhida1;

    Positions mesaEscolhida2;

    Positions mesaEscolhida3;

    Positions localDeSaida;

    private bool primeiroIngrediente = false;

    private bool segundoIngrediente = false;

    private bool terceiroIngrediente = false;

    private Vector3 _originalPosition;

    public bool podeVoltar;

    private Vector2 offset, _posicaoAtual;

    int smoothVelocidade = 1;


    private void Awake()
    {
        sortearMesas();
    }

    void Start()
    {
        SortearPedidoDoCliente();
    }
    void FixedUpdate()
    {
        IngredientePremiumParaOCliente();
        MoverPersonagemPara();
    }

    private void MoverPersonagemPara ()
    {
        if (!mesaEscolhida1.statusDaMesa || mesaEscolhida1.cliente == this)
        {
            VaParaPosicao(mesaEscolhida1);
        }       
        else if (!mesaEscolhida2.statusDaMesa || mesaEscolhida2.cliente == this)
        {
            VaParaPosicao(mesaEscolhida2);
        }
        else if (!mesaEscolhida3.statusDaMesa || mesaEscolhida3.cliente == this)
        {
            VaParaPosicao(mesaEscolhida3);
        }else
        {
            VaParaPosicao(localDeSaida);
        }
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
        sortearNumero = SortearNumeroDoPedido();

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

    public int SortearNumeroDoPedido()
    {
        return Random.Range(0, listaDePedidos.pedidosPossiveis.Length);
    }

    public int SortearLocal(Positions[] posicao)
    {
        return Random.Range(0, posicao.Length);
    }

    public void sortearMesas()
    {
        localDeSaida = posicoesDeEntradaESaida[SortearLocal(posicoesDeEntradaESaida)];

        transform.position = localDeSaida.transform.position;

        mesaEscolhida1 = posicoesDosClientes[SortearLocal(posicoesDosClientes)];
        do
        {
            mesaEscolhida2 = posicoesDosClientes[SortearLocal(posicoesDosClientes)];

        } while (mesaEscolhida1 == mesaEscolhida2);

        do
        {
            mesaEscolhida3 = posicoesDosClientes[SortearLocal(posicoesDosClientes)];

        } while (mesaEscolhida1 == mesaEscolhida3 || mesaEscolhida2 == mesaEscolhida3);
    }

    public void VaParaPosicao(Positions posicao)
    {

        _originalPosition = posicao.transform.position;
        
        _posicaoAtual = transform.position;

        _posicaoAtual = Vector3.Lerp(
            transform.position,
            _originalPosition,
            smoothVelocidade * Time.deltaTime);

        transform.position = _posicaoAtual;
        
    }

    public bool PodeVoltarAPosiçãoInicial()
    {
        return true;
    }

    public bool JaChegouNoDestino()
    {
        return false;
    }
}
