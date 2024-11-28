using UnityEngine;
using UnityEngine.SceneManagement;

public class EnigmaOsiris : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textoFeedback; // Feedback imediato
    public TMPro.TextMeshProUGUI textoPontuacao; // Exibição da pontuação
    public GameObject telaFinal; // Tela de resultados finais
    public TMPro.TextMeshProUGUI textoResultadoFinal; // Texto da tela final

    private int pontuacao = 100; // Pontuação inicial
    private int respostaCorreta = 2; // Número da resposta correta
    private int pontosPorAcerto = 30; // Pontos ganhos por acerto
    private int pontosPorErro = 15; // Pontos perdidos por erro

    public void EscolherResposta(int numeroResposta)
    {
        if (numeroResposta == respostaCorreta)
        {
            pontuacao += pontosPorAcerto;
            textoFeedback.text = "Você respondeu corretamente! Osíris o recebe com sabedoria.";
        }
        else
        {
            pontuacao -= pontosPorErro;

            if (numeroResposta == 1)
                textoFeedback.text = "Resposta incorreta! O Tribunal de Osíris se frustra.";
            else if (numeroResposta == 3)
                textoFeedback.text = "Resposta incorreta! Seu julgamento pende ao desequilíbrio.";
        }

        AtualizarPontuacao();
        VerificarFimDoJogo();
    }

    private void AtualizarPontuacao()
    {
        textoPontuacao.text = "Pontuação: " + pontuacao;
    }

    private void VerificarFimDoJogo()
    {
        if (SceneManager.GetActiveScene().name == "Cena4")
        {
            // Exibe o resultado final
            telaFinal.SetActive(true);

            if (pontuacao >= 50)
                textoResultadoFinal.text = "Parabéns! Sua jornada foi bem-sucedida e você obteve uma segunda chance!";
            else
                textoResultadoFinal.text = "Seu coração pesou mais que a pena de Maat. Você perdeu sua segunda chance.";
        }
        else
        {
            // Caso não seja a última cena, carregar a próxima cena
            SceneManager.LoadScene("UltimaCena");
        }
    }
}
