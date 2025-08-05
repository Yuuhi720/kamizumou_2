using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2 : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.L; // ジャンプ用のキー

    public float maxJumpForce = 20f; // 最大ジャンプ力
    private float jumpCharge = 0f;   // 溜めたジャンプ力

    private Rigidbody2D rb;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //地面に触れているかどうか調べる
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //ジャンプ力を溜める
        if (Input.GetKey(jumpKey) && isGrounded)
        {
            jumpCharge += Time.deltaTime * 10f;
            jumpCharge = Mathf.Clamp(jumpCharge, 0f, maxJumpForce);
        }

        //移動する方向を決める
        if (Input.GetKeyUp(jumpKey) && isGrounded)
        {
            float h = 0f;
            float v = 0f;

            if (Input.GetKey(KeyCode.LeftArrow)) h = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) h = 1f;
            if (Input.GetKey(KeyCode.UpArrow)) v = 1f;


            Vector2 direction = new Vector2(h, v);
            if (direction == Vector2.zero)
                direction = Vector2.up;

            Vector2 force = direction.normalized * jumpCharge;
            rb.AddForce(force, ForceMode2D.Impulse);

            jumpCharge = 0f;
        }
    }

}