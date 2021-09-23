using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestesEDebugs : MonoBehaviour
{
    public enum Sabores
    {
        Amargo,
        Apimentado,
        Azedo,
        Doce,
        Salgado
    }

    [SerializeField] string NomeDoIgrediente;

    [SerializeField] string SaborAmargo = "Amargo";
    [SerializeField] [Range(0, 5)] int intensidadeDoAmargo;

    [SerializeField] string SaborApimentado = "Apimentado";
    [SerializeField] [Range(0, 5)] int intensidadeDoApimentado;

    [SerializeField] string SaborAzedo = "Azedo";
    [SerializeField] [Range(0, 5)] int intensidadeDoAzedo;

    [SerializeField] string SaborDoce = "Doce";
    [SerializeField] [Range(0, 5)] int intensidadeDoDoce;

    [SerializeField] string SaborSalgado = "Salgado";
    [SerializeField] [Range(0, 5)] int intensidadeDoSalgado;



    //public Cor[] UmaCor => umaCor;

}
