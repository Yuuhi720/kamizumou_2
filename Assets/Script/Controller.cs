using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool Rikishi1 = true; // true: AD�L�[�œ���, false: �����L�[�œ���

    Rigidbody2D rb;
    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Vector2.zero;

        if (Rikishi1)
        {
            // A�L�[�ō��ցAD�L�[�ŉE��
            if (Input.GetKey(KeyCode.A)) movement.x = -1;
            if (Input.GetKey(KeyCode.D)) movement.x = 1;
        }
        else
        {
            // ���L�[�ō��ցA���L�[�ŉE��
            if (Input.GetKey(KeyCode.LeftArrow)) movement.x = -1;
            if (Input.GetKey(KeyCode.RightArrow)) movement.x = 1;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}