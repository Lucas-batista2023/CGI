using UnityEngine;
using UnityEngine.SceneManagement;

public class EnigmaPortas : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textoFeedback;
    public TMPro.TextMeshProUGUI textoPontuacao;
    public GameObject telaFinal;
    public TMPro.TextMeshProUGUI textoResultadoFinal;

    private int pontuacao = 100;
    private int portaCorreta = 3;
    private int pontosPorAcerto = 20;
    private int pontosPorErro = 10;

    public void EscolherPorta(int numeroPorta)
    {
        if (numeroPorta == portaCorreta)
        {
            pontuacao += pontosPorAcerto;
            textoFeedback.text = "Você escolheu sabiamente! Bem-vinda ao Submundo.";
            AtualizarPontuacao();
            VerificarFimDoJogo();
        }
        else
        {
            pontuacao -= pontosPorErro;
            AtualizarPontuacao();

            if (numeroPorta == 1)
                textoFeedback.text = "Porta errada! Cleópatra não é a resposta.";
            else if (numeroPorta == 2)
                textoFeedback.text = "Porta errada! Anúbis não é a resposta.";

            VerificarFimDoJogo();
        }
    }

    private void AtualizarPontuacao()
    {
        textoPontuacao.text = "Pontuação: " + pontuacao;
    }

    private void VerificarFimDoJogo()
    {
        if (SceneManager.GetActiveScene().name == "UltimaCena")
        {
            telaFinal.SetActive(true);
            if (pontuacao >= 50)
                textoResultadoFinal.text = "Parabéns! Você obteve uma segunda chance!";
            else
                textoResultadoFinal.text = "Infelizmente, você não obteve uma segunda chance.";
        }
        else
        {
            SceneManager.LoadScene("Cena3");
        }
    }
}
