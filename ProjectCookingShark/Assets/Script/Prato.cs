using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prato : MonoBehaviour
{
    [SerializeField] string nomePrato;
    public string NomePrato => nomePrato;

    [SerializeField] Ingrediente ingredientes01;
    public Ingrediente Ingredientes01 => ingredientes01;

    [SerializeField] Ingrediente ingredientes02;
    public Ingrediente Ingredientes02 => ingredientes02;

    [SerializeField] Ingrediente ingredientes03;
    public Ingrediente Ingredientes03 => ingredientes03;
}
