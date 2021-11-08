using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] GameObject MenuOptions;
    [SerializeField] public GameObject MenuPerguntaSair;
    private void Start()
    {
        MenuOptions.SetActive(false);
        MenuPerguntaSair.SetActive(false);
    }
    public void BotaoJogar()
    {
        Debug.Log("Iniciar o Jogo");
        SceneManager.LoadScene("Jogo");
    }

    public void BotaoHistoria()
    {
        Debug.Log("Iniciar a história do Jogo");
    }
    public void BotaoOpcoes()
    {
        Debug.Log("Abre o menu de opções");
        MenuOptions.SetActive(true);
    }
    public void BotaoSair()
    {
        MenuPerguntaSair.SetActive(true);
        Debug.Log("Fechar o jogo");
    }
}
