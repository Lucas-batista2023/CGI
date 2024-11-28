using UnityEngine;

public class GhostMovement : MonoBehaviour
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
        // Move o fantasma continuamente para a esquerda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Verifica se o fantasma saiu da cena pelo lado esquerdo
        if (transform.position.x < startPosition.x - sceneWidth)
        {
            // Reposiciona o fantasma no início
            transform.position = startPosition;
        }
    }
}
