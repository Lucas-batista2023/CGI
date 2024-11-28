using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrigger : MonoBehaviour
{
 public GameObject enigmaUI; // Arraste aqui o campo/enigma no Inspector.

    void Start()
    {
        if (enigmaUI != null)
        {
            enigmaUI.SetActive(false); // Esconde o enigma no início.
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Certifique-se de que o personagem tem a tag "Player".
        {
            if (enigmaUI != null)
            {
                enigmaUI.SetActive(true); // Mostra o enigma.
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (enigmaUI != null)
            {
                enigmaUI.SetActive(false); // Esconde o enigma ao sair.
            }
        }
    }
}
