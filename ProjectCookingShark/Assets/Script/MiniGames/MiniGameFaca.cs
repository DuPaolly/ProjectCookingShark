using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameFaca : MiniGameBase
{
    int corte = 0;
    public Button faca;
    int limiteDeCorte;
    //private void OnLevelWasLoaded(int level)


    public void Faca()
    {
        if (corte < limiteDeCorte)
        {
            corte++;
            Debug.Log("Mais 1 " + corte);
        }
        else
        {
            corte = 0;
            faca.enabled = false;
            Debug.Log("Ja fooiii");
            EncerraMiniGame();
        }
    }

    public override void InicializaMiniGame(int novoLimiteDeCorte)
    {
        base.InicializaMiniGame(novoLimiteDeCorte);
        limiteDeCorte = novoLimiteDeCorte;
        corte = 0;
        faca.enabled = true;
    }

}
