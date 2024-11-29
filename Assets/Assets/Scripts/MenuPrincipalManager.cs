using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelTutorial;

    public void Jogar()
    {
        // Salva o estado da música antes de carregar o jogo
        SalvarEstadoMusica();

        // Carrega o nível de jogo
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirTutorial()
    {
        painelMenuInicial.SetActive(false);
        painelTutorial.SetActive(true);
    }

    public void FecharTutorial()
    {
        painelTutorial.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }

    void Start()
    {
        // Restaura o estado da música ao abrir o menu principal
        RestaurarEstadoMusica();
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
