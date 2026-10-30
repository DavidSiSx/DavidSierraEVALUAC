using UnityEngine;

public class RebotePared : MonoBehaviour
{
    [SerializeField] private float fuerzaVertical = 12f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D jugador = collision.rigidbody;

        if (jugador == null || !jugador.CompareTag("Player"))
            return;

        if (Mathf.Abs(collision.GetContact(0).normal.x) < 0.5f)
            return;

        jugador.linearVelocity = new Vector2(
            jugador.linearVelocity.x,
            fuerzaVertical
        );
    }
}