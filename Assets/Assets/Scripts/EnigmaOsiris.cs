using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;  // Necessário para usar IEnumerator

public class EnigmaOsiris : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textoFeedback; // Feedback imediato
    public TMPro.TextMeshProUGUI textoPontuacao; // Exibição da pontuação
    public GameObject telaFinal; // Tela de resultados finais
    public TMPro.TextMeshProUGUI textoResultadoFinal; // Texto da tela final

    private int pontosPorPerdoar = 20; // Pontos ganhos por perdoar
    private int pontosPorCondenar = 10; // Pontos ganhos por condenar, mas sem bônus moral
    private int pontosPorErro = 15; // Pontos perdidos por erro
    private float delayAntesDeProximaCena = 2f; // Delay antes de mudar para a próxima cena

    void Start()
    {
        // Exibir a pontuação inicial a partir do PontuacaoManager
        AtualizarPontuacao();
    }

    public void EscolherResposta(int numeroResposta)
    {
        if (numeroResposta == 1) // Perdoar a alma
        {
            PontuacaoManager.instancia.AtualizarPontuacao(pontosPorPerdoar); // Atualiza a pontuação global
            textoFeedback.text = "Você escolheu o caminho da compaixão. Mas lembre-se, a bondade sem sabedoria pode trazer consequências.";
        }
        else if (numeroResposta == 2) // Condenar a alma
        {
            PontuacaoManager.instancia.AtualizarPontuacao(pontosPorCondenar); // Atualiza a pontuação global
            textoFeedback.text = "Você preferiu a justiça. Saiba, porém, que nem toda punição traz redenção.";
        }
        else
        {
            PontuacaoManager.instancia.AtualizarPontuacao(-pontosPorErro); // Subtrai pontos globais
            textoFeedback.text = "Resposta incorreta! Faça sua escolha com sabedoria.";
        }

        AtualizarPontuacao();
        StartCoroutine(VerificarFimDoJogo()); // Inicia a corrotina com delay
    }

    private void AtualizarPontuacao()
    {
        // Atualiza o texto da UI com a pontuação global
        textoPontuacao.text = "Pontuação " + PontuacaoManager.instancia.pontuacao;
    }

    private IEnumerator VerificarFimDoJogo()
    {
        // Aguarda o tempo especificado antes de realizar a próxima ação
        yield return new WaitForSeconds(delayAntesDeProximaCena);

        if (SceneManager.GetActiveScene().name == "Cena4") // Checando se é a última cena
        {
            telaFinal.SetActive(true); // Exibe o painel final

            if (PontuacaoManager.instancia.pontuacao >= 50) // Avaliação da pontuação final
                textoResultadoFinal.text = "Parabéns! Sua jornada foi bem-sucedida e você obteve uma segunda chance!";
            else
                textoResultadoFinal.text = "Seu coração pesou mais que a pena de Maat. Você perdeu sua segunda chance.";
        }
        else
        {
            // Caso não seja a última cena, carregar a próxima cena
            SceneManager.LoadScene("Cena4");
        }
    }
}
