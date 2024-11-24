using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public GameObject dialogCanvas; // Referência ao Canvas do diálogo
    public string dialogMessage = "Bem-vindo ao Submundo!"; // Mensagem padrão

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador entrou no trigger
        if (other.CompareTag("Player"))
        {
            // Ativa o Canvas do diálogo
            if (dialogCanvas != null)
            {
                dialogCanvas.SetActive(true);
                // Opcional: Altera o texto do diálogo dinamicamente
                var textComponent = dialogCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = dialogMessage;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o jogador saiu do trigger
        if (other.CompareTag("Player") && dialogCanvas != null)
        {
            dialogCanvas.SetActive(false); // Desativa o Canvas do diálogo
        }
    }
}
