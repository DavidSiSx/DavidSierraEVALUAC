using UnityEngine;
using UnityEngine.InputSystem;

public class Salto : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto = 10f;
    [SerializeField] private string tagSuelo = "Suelo";

    private Rigidbody2D rb;
    private bool estaEnSuelo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnJump(InputValue value)
    {
        if (!value.isPressed)
            return;

        if (estaEnSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            estaEnSuelo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagSuelo))
        {
            estaEnSuelo = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagSuelo))
        {
            estaEnSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagSuelo))
        {
            estaEnSuelo = false;
        }
    }
}
