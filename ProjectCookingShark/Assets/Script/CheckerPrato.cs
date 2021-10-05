using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPrato : MonoBehaviour
{
    [SerializeField] Prato pratoFeito;
    [SerializeField] Receita[] receitasPossiveis;

    bool pratoExiste = false;

    public bool CheckPrato()
    {
        //pratoFeito.Ingredientes01.Nome = receitasPossiveis[0].ReceitaPrato;
        if(pratoFeito.Ingredientes02 == receitasPossiveis[0].Ingredientes01)
        {
            return !pratoExiste;
        }
        return pratoExiste;
    }
}
