using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController1 : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.W; // ジャンプに使うキー

    public float maxJumpForce = 20f;    // 最大ジャンプ力
    private float jumpCharge = 0f;      // ためたジャンプ力

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

        // ジャンプキーを離したときジャンプ発動
        if (Input.GetKeyUp(jumpKey) && isGrounded)
        {
            // 入力された方向を調べる
            float h = 0f;
            float v = 0f;

            if (Input.GetKey(KeyCode.A)) h = -1f; // 左
            if (Input.GetKey(KeyCode.D)) h = 1f;  // 右
            if (Input.GetKey(KeyCode.S)) v = -1f; // 下
            if (Input.GetKey(KeyCode.W)) v = 1f;  // 上

            Vector2 direction = new Vector2(h, v);

            // 方向が入力されていない場合は、真上にジャンプ
            if (direction == Vector2.zero)
                direction = Vector2.up;

            // 指定方向にジャンプする
            Vector2 force = direction.normalized * jumpCharge;
            rb.AddForce(force, ForceMode2D.Impulse);

            // 状態をリセット
            jumpCharge = 0f;
            isGrounded = false;
        }
    }

    // 地面に着地したときに呼ばれる
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dohyou"))
        {
            isGrounded = true;
        }
    }

    // 地面から離れたときに呼ばれる
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dohyou"))
        {
            isGrounded = false;
        }
    }
}