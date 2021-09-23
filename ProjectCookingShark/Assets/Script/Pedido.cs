using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedido : MonoBehaviour
{
    
    //Dictionary<string, Ingrediente> sabor = new Dictionary<string, Ingrediente>();

    [SerializeField] Sabores.SaboresExistentes sabor01;
    [SerializeField] [Range(0, 10)] int intensidadeSabor01;
    [SerializeField] Sabores.SaboresExistentes sabor02;
    [SerializeField] [Range(0, 10)] int intensidadeSabor02;
    [SerializeField] Ingrediente ingredienteProibido;

}