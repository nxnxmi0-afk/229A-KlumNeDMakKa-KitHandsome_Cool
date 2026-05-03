using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GolfContoller : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        startPosition = transform.position; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            transform.position = startPosition;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        if (other.CompareTag("Hole"))
        {
            SceneManager.LoadScene("End");
        }
    }
}
