using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnigmaPortas : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textoFeedback; // Texto para feedback do jogador
    public TMPro.TextMeshProUGUI textoPontuacao; // Texto para exibir a pontuação na tela
    public GameObject telaFinal; // Painel final
    public TMPro.TextMeshProUGUI textoResultadoFinal; // Texto final com o resultado

    private int portaCorreta = 3; // Número da porta correta
    private int pontosPorAcerto = 20; // Pontos ganhos por acerto
    private int pontosPorErro = 50; // Pontos perdidos por erro
    private float delayParaProximaCena = 2f; // Tempo de espera antes de mudar de cena

    public void EscolherPorta(int numeroPorta)
    {
        if (numeroPorta == portaCorreta)
        {
            PontuacaoManager.instancia.AtualizarPontuacao(pontosPorAcerto); // Atualiza pontuação no manager
            textoFeedback.text = "Você escolheu sabiamente! Bem-vinda ao Submundo.";
        }
        else
        {
            PontuacaoManager.instancia.AtualizarPontuacao(-pontosPorErro); // Penaliza pontuação no manager

            if (numeroPorta == 1)
                textoFeedback.text = "Resposta errada! Anúbis não é a resposta.";
            else if (numeroPorta == 2)
                textoFeedback.text = "Resposta errada! Cleópatra não é a resposta.";
        }

        AtualizarPontuacao();
        StartCoroutine(VerificarFimDoJogo());
    }

    private void AtualizarPontuacao()
    {
        // Atualiza a exibição da pontuação na tela
        textoPontuacao.text = "Pontuação: " + PontuacaoManager.instancia.pontuacao;
    }

    private IEnumerator VerificarFimDoJogo()
    {
        // Aguarda o delay antes de verificar ou mudar de cena
        yield return new WaitForSeconds(delayParaProximaCena);

        if (SceneManager.GetActiveScene().name == "Cena4")
        {
            telaFinal.SetActive(true); // Exibe o painel final

            if (PontuacaoManager.instancia.pontuacao >= 50)
                textoResultadoFinal.text = "Parabéns! Você obteve uma segunda chance!";
            else
                textoResultadoFinal.text = "Infelizmente, você não obteve uma segunda chance.";
        }
        else
        {
            // Salva o estado da música antes de carregar a próxima cena
            SalvarEstadoMusica();

            // Carrega a próxima cena
            SceneManager.LoadScene("Cena3");
        }
    }

    void Start()
    {
        AtualizarPontuacao(); // Atualiza a pontuação ao iniciar a cena
        RestaurarEstadoMusica(); // Restaura o estado da música
    }

    private void SalvarEstadoMusica()
    {
        // Obtém o AudioManager e salva o tempo atual da música
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            float currentTime = audioManager.GetCurrentTime();
            PlayerPrefs.SetFloat("MusicTime", currentTime);
        }
    }

    private void RestaurarEstadoMusica()
    {
        // Obtém o AudioManager e redefine o tempo da música se houver dados salvos
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null && PlayerPrefs.HasKey("MusicTime"))
        {
            float savedTime = PlayerPrefs.GetFloat("MusicTime");
            audioManager.SetCurrentTime(savedTime);
        }
    }
}
