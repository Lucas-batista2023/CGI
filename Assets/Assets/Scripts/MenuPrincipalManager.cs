using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelTutorial;
    public void Jogar(){
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirTutorial(){
        painelMenuInicial.SetActive(false);
        painelTutorial.SetActive(true);
    } 

    public void FecharTutorial(){
        painelTutorial.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo(){
        Debug.Log("sair do jogo");
        Application.Quit();
    }
}
