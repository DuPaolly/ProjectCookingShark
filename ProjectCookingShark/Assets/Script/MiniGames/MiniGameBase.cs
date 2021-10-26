using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBase : MonoBehaviour
{
    [SerializeField] GameObject canvasMiniGame;
    protected bool miniGameEmProducao;
    public bool MiniGameEmProdução => miniGameEmProducao;

    public virtual void InicializaMiniGame(int condicaoDeEncerramento)
    {
        canvasMiniGame.SetActive(true);
        miniGameEmProducao = true;
    }

    public virtual void EncerraMiniGame()
    {
        canvasMiniGame.SetActive(false);
        miniGameEmProducao = false;
    }


}
