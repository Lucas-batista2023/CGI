using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextSceneName; // Nome da próxima cena

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Antes de carregar a próxima cena, salva o tempo atual da música
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
            {
                float currentTime = audioManager.GetCurrentTime();
                PlayerPrefs.SetFloat("MusicTime", currentTime);
            }

            // Carrega a próxima cena
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void Start()
    {
        // Ao carregar uma nova cena, redefine o tempo da música
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null && PlayerPrefs.HasKey("MusicTime"))
        {
            float savedTime = PlayerPrefs.GetFloat("MusicTime");
            audioManager.SetCurrentTime(savedTime);
        }
    }
}
