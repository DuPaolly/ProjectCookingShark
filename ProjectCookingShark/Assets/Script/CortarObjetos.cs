using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CortarObjetos : MonoBehaviour
{
    int corte = 0;

    public void Faca()
    {
        if (corte <=5)
        {
            corte++;
            Debug.Log("Mais 1");
        }
        else
        {
            Debug.Log("Ja fooiii");
        }
    }

}
