using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPrato : MonoBehaviour
{
    [SerializeField] Prato pratoFeito;
    [SerializeField] Receita[] receitasPossiveis;

    bool ingrediente1Achado = false;
    bool ingrediente2Achado = false;
    private void Update()
    {
        CheckPrato();
    }
    public Receita CheckPrato()
    {
        for (int i = 0; i < receitasPossiveis.Length; i++)
        {
            if (ingrediente1Achado == false && ingrediente2Achado == false)
            {
                if (pratoFeito.Ingredientes01 == receitasPossiveis[i].Ingredientes01 ||
               pratoFeito.Ingredientes01 == receitasPossiveis[i].Ingredientes02)
                {
                    ingrediente1Achado = true;
                    Debug.Log("ACHEI O 1 MERMAO");
                }
                if (pratoFeito.Ingredientes02 == receitasPossiveis[i].Ingredientes02 ||
                    pratoFeito.Ingredientes02 == receitasPossiveis[i].Ingredientes02)
                {
                    ingrediente2Achado = true;
                    Debug.Log("ACHEI O 2 MERMAO");
                }
            }
            if(ingrediente1Achado == true && ingrediente2Achado == true)
            {
                Debug.Log("ACHEI A RECEITA MERMAO");
                return receitasPossiveis[i];
            }
            else
            {
                Debug.Log("GOROROBAAAAA CHEECKKK");
                return receitasPossiveis[0];
            }
           
        }
        Debug.Log("GOROROBA MANÉ");
        return receitasPossiveis[0];
    }
}
//Debug.Log("VOU RETORNA A RECEITA EM");
//return receitasPossiveis[i];