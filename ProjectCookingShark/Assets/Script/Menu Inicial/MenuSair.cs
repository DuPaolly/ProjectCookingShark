using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSair : MenuInicial
{
    public void SimSair()
    {
        Debug.Log("To fechandoooo");
        Application.Quit();
    }
    public void NaoSair()
    {
        MenuPerguntaSair.SetActive(false);
    }
}
