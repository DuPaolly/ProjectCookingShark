using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public enum SaboresExistentes
    {
        Doce,
        Salgado,
        Apimentado,
        Azedo,
        Agridoce
    }

    [SerializeField] string nome;
    public string Nome => nome;
    [SerializeField] SaboresExistentes sabor;
    SaboresExistentes Sabor => sabor;
    [SerializeField] [Range(0, 5)] int intensidade;
    public int Intensidade => intensidade;
    //
    [SerializeField] SaboresExistentes sabor02;
    SaboresExistentes Sabor02 => sabor02;
    [SerializeField] [Range(0, 5)] int intensidade02;
    public int Intensidade02 => intensidade02;
    //

}
