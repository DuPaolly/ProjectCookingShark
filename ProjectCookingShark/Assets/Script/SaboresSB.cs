using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabores : MonoBehaviour
{
    public enum SaboresExistentes
    {
        Doce,
        Salgado,
        Apimentado,
        Azedo, 
        Agridoce
    }

    [SerializeField] SaboresExistentes sabor;
    SaboresExistentes Sabor => sabor;
    [SerializeField] [Range(0, 5)] int intensidade;
    public int Intensidade => intensidade;
}
