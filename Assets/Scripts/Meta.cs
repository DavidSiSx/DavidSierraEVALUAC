using UnityEngine;

public class Meta : MonoBehaviour
{
    private bool ganaste;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ganaste || !other.CompareTag("Player"))
            return;

        ganaste = true;
        Debug.Log("ganaste");
    }
}
