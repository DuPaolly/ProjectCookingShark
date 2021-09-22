using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestesEDebugs : MonoBehaviour
{
    public enum Cor
    {

        Branco,
        Preto,
        Azul,
        Vermelho

    }

    [SerializeField] [Range(0, 5)] int intensidade;
    [SerializeField] Cor[] umaCor;
 

    //public Cor[] UmaCor => umaCor;

}
