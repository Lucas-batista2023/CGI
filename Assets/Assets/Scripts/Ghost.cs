using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float speed = 2f; // Velocidade do fantasma
    public float sceneWidth = 10f; // Largura da cena (ajuste conforme necessário)

    private Vector3 startPosition; // Posição inicial do fantasma

    void Start()
    {
        // Define a posição inicial como a posição atual
        startPosition = transform.position;
    }

    void Update()
    {
        // Move o fantasma continuamente para a direita
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Verifica se o fantasma saiu da cena pelo lado direito
        if (transform.position.x > startPosition.x + sceneWidth)
        {
            // Reposiciona o fantasma no início
            transform.position = startPosition;
        }
    }
}
