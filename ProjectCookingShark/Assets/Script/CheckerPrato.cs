using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPrato : MonoBehaviour
{
    [SerializeField] Prato pratoFeito;
    [SerializeField] Receita[] receitasPossiveis;

    bool ingrediente1Achado = false;
    bool ingrediente2Achado = false;
    int  id = 0;
    private void Update()
    {
        CheckPrato();
    }
    public Receita CheckPrato()
    {
        while (ingrediente1Achado == false || ingrediente2Achado == false) 
        {
            if (id >= receitasPossiveis.Length)
            {
                Debug.Log("GOROROBAAA CHECKKK");
                return receitasPossiveis[0];
            }

            if (pratoFeito.Ingredientes01 == receitasPossiveis[id].Ingredientes01 ||
                pratoFeito.Ingredientes01 == receitasPossiveis[id].Ingredientes02)
            {
                ingrediente1Achado = true;
                Debug.Log("Achei o 1");
            }

            if(pratoFeito.Ingredientes02 == receitasPossiveis[id].Ingredientes01 ||
                pratoFeito.Ingredientes02 == receitasPossiveis[id].Ingredientes02)
            {
                ingrediente2Achado = true;
                Debug.Log("Achei o 2");
            }
            
            if (ingrediente1Achado == false && ingrediente2Achado == true || ingrediente1Achado == true && ingrediente2Achado == false)
            {
                ingrediente1Achado = false;
                ingrediente2Achado = false;
            }

            id++;

            if (ingrediente1Achado == true && ingrediente2Achado == true)
            {
                id--;
            }
        }

        Debug.Log("Oia s� q receita bunita");
        Debug.Log(receitasPossiveis[id]);
        return receitasPossiveis[id];

    }
}

