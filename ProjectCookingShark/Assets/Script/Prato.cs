using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prato : MonoBehaviour
{
    [SerializeField] string nomePrato;
    public string NomePrato => nomePrato;
    [SerializeField] Ingrediente[] ingredientes;
    public Ingrediente[] Ingredientes => ingredientes;
}
