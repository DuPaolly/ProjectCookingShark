using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameFaca : MonoBehaviour
{
    int corte = 0;
    public Button faca;

    private void OnLevelWasLoaded(int level)
    {
        faca.enabled = true;
    }

    public void Faca()
    {
        //faca.enabled = true;
        if (corte <5)
        {
            corte++;
            Debug.Log("Mais 1 " + corte);
        }
        else
        {
            corte = 0;
            faca.enabled = false;
            Debug.Log("Ja fooiii");
        }
    }

}
