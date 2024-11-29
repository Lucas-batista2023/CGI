using UnityEngine;
using UnityEngine.SceneManagement;

public class PontuacaoManager : MonoBehaviour
{
    public static PontuacaoManager instancia; // Instância do singleton
    public int pontuacao = 100; // Pontuação inicial

    // Garantir que o objeto persista entre as cenas
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Não destrua este objeto entre as cenas
        }
        else
        {
            Destroy(gameObject); // Se já existir, destrua esse objeto
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "cena1")
        {
            ResetarPontuacao();
        }
    }

    public void ResetarPontuacao()
    {
        pontuacao = 100;
    }

    public void AtualizarPontuacao(int pontos)
    {
        pontuacao += pontos;
    }
}
