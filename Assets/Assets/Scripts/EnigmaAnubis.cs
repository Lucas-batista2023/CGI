using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;  // Adicionado para permitir o uso de IEnumerator

public class EnigmaAnubis : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textoFeedback; // Feedback para o jogador
    public TMPro.TextMeshProUGUI textoPontuacao; // Exibição da pontuação
    public GameObject telaFinal; // Tela final de resultado
    public TMPro.TextMeshProUGUI textoResultadoFinal; // Texto de resultado no painel final

    private int pontosPorAcerto = 30; // Pontos para uma resposta correta
    private int pontosPorErro = 15;  // Pontos perdidos para uma resposta errada
    private int respostaCorreta = 2; // Resposta correta é a opção 2 (Anúbis)
    private float delayParaProximaCena = 2f; // Delay antes de mudar para a próxima cena ou mostrar o resultado

    public void EscolherResposta(int numeroResposta)
    {
        // Se o jogador acertar a resposta
        if (numeroResposta == respostaCorreta)
        {
            PontuacaoManager.instancia.AtualizarPontuacao(pontosPorAcerto); // Atualiza pontuação através do PontuacaoManager
            textoFeedback.text = "Você escolheu sabiamente!";
        }
        else
        {
            // Se o jogador errar, subtrai a pontuação
            PontuacaoManager.instancia.AtualizarPontuacao(-pontosPorErro);
            
            if (numeroResposta == 1)
                textoFeedback.text = "Resposta errada! Horus não é o guardião do portal.";
            else if (numeroResposta == 3)
                textoFeedback.text = "Resposta errada! Bastet não é a deusa do julgamento.";
        }

        AtualizarPontuacao();
        StartCoroutine(VerificarFimDoJogo());  // Inicia a corrotina para verificar o fim do jogo com delay
    }

    private void AtualizarPontuacao()
    {
        // Atualiza a pontuação na UI
        textoPontuacao.text = "Pontuação " + PontuacaoManager.instancia.pontuacao;
    }

    private IEnumerator VerificarFimDoJogo()
    {
        // Aguarda o delay antes de fazer a verificação
        yield return new WaitForSeconds(delayParaProximaCena);

        // Quando o jogador terminar o enigma e chegar na última cena, mostra o painel final
        if (SceneManager.GetActiveScene().name == "Cena4")
        {
            telaFinal.SetActive(true); // Ativa a tela final com a pontuação

            if (PontuacaoManager.instancia.pontuacao >= 50)
                textoResultadoFinal.text = "Parabéns! Você passou pelo julgamento de Anúbis e obteve uma segunda chance!";
            else
                textoResultadoFinal.text = "Você não passou pelo julgamento. Anúbis não lhe concede uma segunda chance.";
        }
        else
        {
            // Caso contrário, continua para a próxima cena após o delay
            SceneManager.LoadScene("Cena4"); // Carrega a cena final
        }
    }

    void Start()
    {
        // Atualiza a pontuação ao iniciar a cena
        AtualizarPontuacao();
    }
}
