using UnityEngine;

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

    public void AtualizarPontuacao(int pontos)
    {
        pontuacao += pontos;
    }
}
