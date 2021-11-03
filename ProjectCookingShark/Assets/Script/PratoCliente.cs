using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PratoCliente : MonoBehaviour
{
    public Receita pratoAReceber;

    Sabores.SaboresExistentes SaborPremium;

    Ingrediente ingredienteProibidoDoCliente;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PodeReceberPrato(Receita pratoParaAdicionar)
    {
        pratoAReceber = pratoParaAdicionar;

        return true;
    }

}
