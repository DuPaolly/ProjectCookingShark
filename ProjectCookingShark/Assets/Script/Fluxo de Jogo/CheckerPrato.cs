using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPrato : MonoBehaviour
{
    [SerializeField] Frigideira pratoFeito;
    [SerializeField] Receita[] receitasPossiveis;
    [SerializeField] SpriteRenderer spritePrato;

    public bool ingrediente1Achado = false;
    public bool ingrediente2Achado = false;
    public int  id = 0;
    private void Start()
    {
        spritePrato.gameObject.SetActive(false);

    }

    public Receita CheckPrato(Frigideira pratoFeito)
    {
        while (ingrediente1Achado == false || ingrediente2Achado == false) 
        {
            if (id >= receitasPossiveis.Length)
            {
                Debug.Log("GOROROBAAA CHECKKK");
                AtualizaSpriteDoPrato(receitasPossiveis[0].spriteDaReceita);
                return receitasPossiveis[0];

            }

            if (pratoFeito.ingredientes01.NomeDoIngrediente.Equals(receitasPossiveis[id].ingredientes01.NomeDoIngrediente) ||
                pratoFeito.ingredientes01.NomeDoIngrediente.Equals(receitasPossiveis[id].ingredientes02.NomeDoIngrediente))
            {
                ingrediente1Achado = true;
                Debug.Log("Achei o 1");
            }

            if(pratoFeito.ingredientes02.NomeDoIngrediente.Equals(receitasPossiveis[id].ingredientes01.NomeDoIngrediente) ||
                pratoFeito.ingredientes02.NomeDoIngrediente.Equals(receitasPossiveis[id].ingredientes02.NomeDoIngrediente))
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

        Debug.Log("Oia só q receita bunita");
        Debug.Log(receitasPossiveis[id]);
        
        AtualizaSpriteDoPrato(receitasPossiveis[id].spriteDaReceita);
        return receitasPossiveis[id];
        
    }

    public void PodeVerificarOPrato()
    {
        if(ingrediente1Achado != false || ingrediente2Achado != false)
        {
            Debug.Log("Você não pode fazer isso!");
        }
        else
        {
            pratoFeito.receitaAtual = CheckPrato(pratoFeito);
        }

    }

    //[SerializeField] Text TextoPrato;
    //TextoPrato.text = "Arroz";
    //TextoPrato.gameObject.SetActive(true);
    //[SerializeField] SpriteRenderer spritePrato;

    void AtualizaSpriteDoPrato(Sprite spriteDoPrato)
    {
        pratoFeito.ingredientes01.gameObject.SetActive(false);
        pratoFeito.ingredientes02.gameObject.SetActive(false);
        spritePrato.gameObject.SetActive(true);
        spritePrato.sprite = spriteDoPrato;
    }
}

