using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    [SerializeField] 

    int pontuacao = 0;

    ClienteManager manager;

    public int sortearNumero;

    [SerializeField] public ListaDePedidos listaDePedidos;

    public Pedido pedidoDoCliente;

    public Receita pratoRecebido = null;

    public Frigideira.IngredientePremium ingredientePremium;

    public Ingrediente saborPremiumIngrediente;

    [SerializeField] public Positions posicoesDeEntradaESaida;

    [SerializeField] public Positions[] posicoesDosClientes;

    Positions mesaEscolhida1;

    Positions mesaEscolhida2;

    Positions mesaEscolhida3;

    Positions mesaEscolhida4;

    Positions localDeSaida;

    Cliente clienteDetectado;

    private Positions localDetectado;

    [SerializeField] [Range (1,4)] public int prioridadeDoCliente;

    private bool primeiroIngrediente = false;

    private bool segundoIngrediente = false;

    private bool terceiroIngrediente = false;

    private Vector3 _originalPosition;

    public bool podeIr;

    private Vector2 offset, _posicaoAtual;

    [SerializeField] [Range(0, 1)] float smoothVelocidade = 1;

    private void Awake()
    {
        _originalPosition = posicoesDeEntradaESaida.transform.position;
        transform.position = posicoesDeEntradaESaida.transform.position;
        sortearMesas();
    }

    void Start()
    {

    }
    void FixedUpdate()
    {
        IngredientePremiumParaOCliente();
        managerCliente();
    }

    private void OnTriggerEnter2D(Collider2D areaEmQueEncostou)
    {
        Cliente clienteAchado = areaEmQueEncostou.GetComponent<Cliente>();

        if (clienteAchado != null)
        {
            clienteDetectado = clienteAchado;
        }

        Positions localAchado = areaEmQueEncostou.GetComponent<Positions>();

        if (localAchado != null)
        {
            localDetectado = localAchado;
        }
    }

    private void OnTriggerExit2D(Collider2D areaEmQueSaiu)
    {

        Cliente clienteAchado = areaEmQueSaiu.GetComponent<Cliente>();

        if (clienteAchado != null)
        {
            clienteDetectado = null;
        }

        Positions localAchado = areaEmQueSaiu.GetComponent<Positions>();

        if (localAchado != null)
        {
            localDetectado = null;
        }
    }

    private void MoverPersonagemPara ()
    {
        if (clienteDetectado != null)
        {
            if (!mesaEscolhida1.statusDaMesa || mesaEscolhida1.cliente.prioridadeDoCliente < this.prioridadeDoCliente || mesaEscolhida1.cliente == this)
        {
            VaParaPosicao(mesaEscolhida1);
        }
        else if (!mesaEscolhida2.statusDaMesa || mesaEscolhida2.cliente.prioridadeDoCliente < this.prioridadeDoCliente || mesaEscolhida2.cliente == this)
        {
            VaParaPosicao(mesaEscolhida2);
        }
        else if (!mesaEscolhida3.statusDaMesa || mesaEscolhida3.cliente.prioridadeDoCliente < this.prioridadeDoCliente || mesaEscolhida3.cliente == this)
        {
            VaParaPosicao(mesaEscolhida3);
        }
        else if (!mesaEscolhida4.statusDaMesa || mesaEscolhida4.cliente.prioridadeDoCliente < this.prioridadeDoCliente || mesaEscolhida4.cliente == this)
        {
            VaParaPosicao(mesaEscolhida4);
        }
        else
        {
            VaParaPosicao(localDeSaida);
        }
        }
        else
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
            }
            else if (!mesaEscolhida4.statusDaMesa || mesaEscolhida4.cliente == this)
            {
                VaParaPosicao(mesaEscolhida4);
            }
            else
            {
                VaParaPosicao(localDeSaida);
            }
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

    void managerCliente()
    {
        if (pratoRecebido == null)
        {
            if (localDetectado != null && !localDetectado.mesa)
            {
                sortearMesas();
                MoverPersonagemPara();
            }
            else if (localDetectado != null && localDetectado.mesa)
            {
                MoverPersonagemPara();
                if (pedidoDoCliente == null)
                {
                    SortearPedidoDoCliente();
                }         
            }
            else
            {
                MoverPersonagemPara();
            }
        }
        else 
        {
            VaParaPosicao(posicoesDeEntradaESaida);
            Pontuacao();
            if (localDetectado != null)
            {
                if (localDetectado.Equals(posicoesDeEntradaESaida))
                {
                    pratoRecebido = null;
                    pedidoDoCliente = null;
                }
            }
        }
    }

    public int SortearLocal(Positions[] posicao)
    {
        return Random.Range(0, posicao.Length);
    }

    public void sortearMesas()
    {

        mesaEscolhida1 = posicoesDosClientes[SortearLocal(posicoesDosClientes)];

        do
        {
            mesaEscolhida2 = posicoesDosClientes[SortearLocal(posicoesDosClientes)];

        } while (mesaEscolhida1 == mesaEscolhida2);

        do
        {
            mesaEscolhida3 = posicoesDosClientes[SortearLocal(posicoesDosClientes)];

        } while (mesaEscolhida1 == mesaEscolhida3 || mesaEscolhida2 == mesaEscolhida3);

        do
        {
            mesaEscolhida4 = posicoesDosClientes[SortearLocal(posicoesDosClientes)];

        } while (mesaEscolhida1 == mesaEscolhida4 || mesaEscolhida2 == mesaEscolhida4 || mesaEscolhida3 == mesaEscolhida4);

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
