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
            saborPremiumIngrediente = ingredientes01;
            //Debug.Log("estao iguais manolos");
        }
        else if (premiumIngredientes == IngredientePremium.SegundoIngredientePremium)
        {
            saborPremiumIngrediente = ingredientes02;
            //Debug.Log("estao iguais manolos, mas ao segundo");
        }
        else
        {
            //Debug.Log("Tem ninguem aqui nao");
            saborPremiumIngrediente = null;
        }
    }
    
    public bool PodeReceberIngrediente(Ingrediente ingredienteParaAdicionar)
    {
        if(ingredientes01 == null && ingredientes02 == null)
        {
            ingredientes01 = ingredienteParaAdicionar;
            return true;
        }
        else if(ingredientes01 != null && ingredientes02 != null)
        {
            return false;
        }
        else
        {
            if (ingredientes01 != null)
            {
                if(ingredientes01 == ingredienteParaAdicionar)
                {
                    return false;
                }
                else
                {
                    ingredientes02 = ingredienteParaAdicionar;
                    return true;
                }
            }
            else
            {
                if (ingredientes02 == ingredienteParaAdicionar)
                {
                    return false;
                }
                else
                {
                    ingredientes01 = ingredienteParaAdicionar;
                    return true;
                }
            }
        }
    }


    public void DescartaIngrediente()
    {
        if (ingredientes01 != null)
        {
            Destroy(ingredientes01.gameObject);
        }
        if (ingredientes02 != null)
        {
            Destroy(ingredientes02.gameObject);
        }
        premiumIngredientes = IngredientePremium.SemIngredientePremium;
    }
}
