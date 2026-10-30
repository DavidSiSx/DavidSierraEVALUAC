using UnityEngine;

public class Daño : MonoBehaviour
{
    [SerializeField] private string tagJugador = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MatarJugador(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MatarJugador(other.gameObject);
    }

    private void MatarJugador(GameObject objeto)
    {
        if (objeto.CompareTag(tagJugador))
        {
            Destroy(objeto);
        }
    }
}
