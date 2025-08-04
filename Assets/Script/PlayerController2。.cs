
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2 : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.L; // ジャンプに使うキー

    public float maxJumpForce = 20f;    // 最大ジャンプ力
    private float jumpCharge = 0f;      // 溜めたジャンプ力

    private Rigidbody2D rb;
    private bool isGrounded = false;    // 地面に接しているかどうか

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 地面にいて、ジャンプキーを長押ししている間はジャンプ力を溜める
        if (Input.GetKey(jumpKey) && isGrounded)
        {
            jumpCharge += Time.deltaTime * 10f; // 毎秒10ずつチャージ
            jumpCharge = Mathf.Clamp(jumpCharge, 0, maxJumpForce); // 上限あり
        }

        // ジャンプキーを離したときジャンプ
        if (Input.GetKeyUp(jumpKey) && isGrounded)
        {
            // 入力された方向を調べる
            float h = 0f;
            float v = 0f;
            if (Input.GetKey(KeyCode.LeftArrow)) h = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) h = 1f;
            if (Input.GetKey(KeyCode.UpArrow)) v = 1f;

            Vector2 direction = new Vector2(h, v);

            // 方向が入力されていない場合は、真上にジャンプ
            if (direction == Vector2.zero)
                direction = Vector2.up;

            // 指定方向に移動する
            Vector2 force = direction.normalized * jumpCharge;
            rb.AddForce(force, ForceMode2D.Impulse);

            // 状態をリセット
            jumpCharge = 0f;
            isGrounded = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dohyou"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dohyou"))
        {
            isGrounded = false;
        }
    }
}