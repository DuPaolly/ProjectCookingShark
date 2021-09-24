using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Prato : MonoBehaviour
{
    [SerializeField] string nomePrato;
    public string NomePrato => nomePrato;

    [SerializeField] Ingrediente ingredientes01;
    public Ingrediente Ingredientes01 => ingredientes01;

    [SerializeField] Ingrediente ingredientes02;
    public Ingrediente Ingredientes02 => ingredientes02;

    Ingrediente saborPremiumIngrediente;

    [SerializeField] IngredientePremium premiumIngredientes;
    public IngredientePremium PremiumIngredientes => premiumIngredientes;

    public enum IngredientePremium
    {
        SemIngredientePremium,
        ComOPrimeiroIngredientePremium,
        ComOSegundoIngredientePremium
    }


    private void Update()
    {
        ingredientePremium();
    }
    
    void ingredientePremium()
    {
        if (premiumIngredientes == IngredientePremium.ComOPrimeiroIngredientePremium)
        {
            saborPremiumIngrediente = ingredientes01;
            Debug.Log("estao iguais manolos");
        }
        else if (premiumIngredientes == IngredientePremium.ComOSegundoIngredientePremium)
        {
            saborPremiumIngrediente = ingredientes02;
            Debug.Log("estao iguais manolos, mas ao segundo");
        }
        else
        {
            Debug.Log("Tem ninguem aqui nao");
            saborPremiumIngrediente = null;
        }
    }


}
