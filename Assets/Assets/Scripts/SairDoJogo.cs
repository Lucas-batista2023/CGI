using UnityEngine;

public class SairDoJogo : MonoBehaviour
{
    // Tecla para sair do jogo (alterado para Escape)
    public KeyCode teclaParaSair = KeyCode.Escape;

    void Update()
    {
        // Verifica se a tecla configurada foi pressionada
        if (Input.GetKeyDown(teclaParaSair))
        {
            Sair();
        }
    }

    // Função para sair do jogo
    void Sair()
    {
        #if UNITY_EDITOR
        // Se estiver no Editor, para a execução (não fecha o editor)
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Caso contrário, fecha o jogo
        Application.Quit();
        #endif
    }
}
