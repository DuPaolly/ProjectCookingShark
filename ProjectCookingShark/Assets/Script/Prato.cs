using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Prato : Receita
{  

    Ingrediente saborPremiumIngrediente;

    [SerializeField] IngredientePremium premiumIngredientes;
    public IngredientePremium PremiumIngredientes => premiumIngredientes;

    public enum IngredientePremium
    {
        SemIngredientePremium,
        PrimeiroIngredientePremium,
        SegundoIngredientePremium
    }


    private void FixedUpdate()
    {
        ingredientePremium();
    }
    
    void ingredientePremium()
    {
        if (premiumIngredientes == IngredientePremium.PrimeiroIngredientePremium)
        {
            saborPremiumIngrediente = Ingredientes01;
            Debug.Log("estao iguais manolos");
        }
        else if (premiumIngredientes == IngredientePremium.SegundoIngredientePremium)
        {
            saborPremiumIngrediente = Ingredientes02;
            Debug.Log("estao iguais manolos, mas ao segundo");
        }
        else
        {
            Debug.Log("Tem ninguem aqui nao");
            saborPremiumIngrediente = null;
        }
    }
}
