using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance; // Instância única para o AudioManager
    private AudioSource audioSource;

    void Awake()
    {
        // Garante que o AudioManager é único
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return; // Evita executar o restante do código em objetos duplicados
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Inicia a música caso não esteja tocando
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public float GetCurrentTime()
    {
        // Retorna o tempo atual da música
        return audioSource.time;
    }

    public void SetCurrentTime(float time)
    {
        // Define o tempo atual da música
        audioSource.time = time;
    }
}
