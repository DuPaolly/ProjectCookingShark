using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PratoCliente : MonoBehaviour
{
    public Prato pratoAReceber;

    Sabores.SaboresExistentes SaborPremium;

    Ingrediente ingredienteProibidoDoCliente;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PodeReceberPrato(Prato pratoParaAdicionar)
    {
        return pratoParaAdicionar;
    }

}
