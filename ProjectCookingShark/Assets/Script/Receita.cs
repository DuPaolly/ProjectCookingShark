using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Receita : MonoBehaviour
{
    [SerializeField] string nomePrato;
    public string NomePrato => nomePrato;

    [SerializeField] Ingrediente ingredientes01;
    public Ingrediente Ingredientes01 => ingredientes01;

    [SerializeField] Ingrediente ingredientes02;
    public Ingrediente Ingredientes02 => ingredientes02;

}
