using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ohyou : MonoBehaviour
{
    public float shakeForce = 100f; 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // —Ž‰º–hŽ~
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 force = Vector2.up * shakeForce;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
}