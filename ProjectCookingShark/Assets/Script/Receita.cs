using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Receita : MonoBehaviour
{
    [SerializeField] string nomePrato;
    public string NomePrato => nomePrato;

    [SerializeField] Ingrediente ingredientes01;
    public Ingrediente Ingredientes01 => ingredientes01;

    [SerializeField] Ingrediente ingredientes02;
    public Ingrediente Ingredientes02 => ingredientes02;

    private void Update()
    {
        TirarIngredienteDuplicado();
    }

    private void TirarIngredienteDuplicado()
    {
        if (ingredientes01 == ingredientes02 && ingredientes01 != null || ingredientes02 != null)
        {
            ingredientes02 = null;
            //    Debug.Log("vamo apagar esse bagulho?");
        }
    }

}
