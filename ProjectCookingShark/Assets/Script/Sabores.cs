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

}
