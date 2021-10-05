using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPrato : MonoBehaviour
{
    [SerializeField] Prato pratoFeito;
    Receita receitaExistente;
    ListaDeReceitas[] receitasPossiveis;

    bool pratoExiste = false;

    public bool CheckPrato()
    {
        //pratoFeito.Ingredientes01.Nome = receitasPossiveis[0].ReceitaPrato;

        return pratoExiste = true;
    }
}
