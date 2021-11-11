using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogoUILvl01 : MonoBehaviour
{
    [SerializeField] GameObject MenuDeIngredientes;

    private void Start()
    {
        MenuDeIngredientes.SetActive(false);
    }

    public void BotaoIngredientes()
    {
        MenuDeIngredientes.SetActive(true);
    }
}
