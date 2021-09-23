using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : Sabores
{

    [SerializeField] string nome;
    public string Nome => nome;
    [SerializeField] Sabores.SaboresExistentes sabor;
    Sabores.SaboresExistentes Sabor => sabor;

}
