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
      // CheckPrato(pratoFeito);
    }

    public void PodeChecarOPrato()
    {
        Receita receitaPreparada;

        if (pratoFeito.ingredientes01 == null || pratoFeito.ingredientes02 == null)
        {
            Debug.Log("Você não pode fazer isso!");
        }
        else
        {

            Debug.Log(pratoFeito.ingredientes01.NomeDoIngrediente);
            Debug.Log(pratoFeito.ingredientes02.NomeDoIngrediente);

            receitaPreparada = CheckPrato(pratoFeito);
        }
    }

    public Receita CheckPrato(Prato pratoFeito)
    {
        while (ingrediente1Achado == false || ingrediente2Achado == false) 
        {
            if (id >= receitasPossiveis.Length)
            {
                Debug.Log("GOROROBAAA CHECKKK");
                return receitasPossiveis[0];
            }

            Debug.Log(id);

            if (pratoFeito.ingredientes01.NomeDoIngrediente.Equals(receitasPossiveis[id].ingredientes01.NomeDoIngrediente) ||
                pratoFeito.ingredientes01.NomeDoIngrediente.Equals(receitasPossiveis[id].ingredientes02.NomeDoIngrediente))
            {
                ingrediente1Achado = true;
                Debug.Log("Achei o 1");
            }

            if (pratoFeito.ingredientes02.NomeDoIngrediente.Equals(receitasPossiveis[id].ingredientes01.NomeDoIngrediente) ||
                pratoFeito.ingredientes02.NomeDoIngrediente.Equals(receitasPossiveis[id].ingredientes02.NomeDoIngrediente))
            {
                ingrediente2Achado = true;
                Debug.Log("Achei o 2");
            }
            
            if (ingrediente1Achado == false && ingrediente2Achado == true || ingrediente1Achado == true && ingrediente2Achado == false)
            {
                Debug.Log("so achei um");
                ingrediente1Achado = false;
                ingrediente2Achado = false;
            }

            id++;

            if (ingrediente1Achado == true && ingrediente2Achado == true)
            {
                id--;
            }
        }

        Debug.Log("Oia só q receita bunita");
        Debug.Log(receitasPossiveis[id]);
        return receitasPossiveis[id];

    }
}

