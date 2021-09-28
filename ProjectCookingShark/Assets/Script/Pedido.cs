using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedido : Sabores
{
    [SerializeField] Sabores.SaboresExistentes saborPedido01;
    public Sabores.SaboresExistentes SaborPedido01 => saborPedido01;

    [SerializeField] Sabores.SaboresExistentes saborPedido02;
    public Sabores.SaboresExistentes SaborPedido02 => saborPedido02;

    [SerializeField] Ingrediente ingredienteProibidoPedido;
    public Ingrediente IngredienteProibidoPedido => ingredienteProibidoPedido;
}