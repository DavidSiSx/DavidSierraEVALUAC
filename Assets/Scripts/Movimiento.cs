using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float finRebote; 

    private Rigidbody2D rb;
    private float direccionHorizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        direccionHorizontal = input.x;
    }

    private void FixedUpdate()
{
    if (Time.time < finRebote)
        return;

    rb.linearVelocity = new Vector2(
        direccionHorizontal * moveSpeed,
        rb.linearVelocity.y
    );
}

private void OnCollisionEnter2D(Collision2D collision)
{
    PhysicsMaterial2D material = collision.collider.sharedMaterial;

    if (material == null || material.bounciness <= 0f)
        return;

    for (int i = 0; i < collision.contactCount; i++)
    {
        if (Mathf.Abs(collision.GetContact(i).normal.x) > 0.5f)
        {
            finRebote = Time.time + 0.5f;
            break;
        }
    }
}
}