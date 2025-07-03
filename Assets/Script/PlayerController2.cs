using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2 : MonoBehaviour
{
    public KeyCode controlKey = KeyCode.L; // 操作キー（AキーやLキーなど）
    public float tapForce = 10f;            // ジャンプ時に加える力の大きさ

    private Rigidbody2D rb;
    private bool isGrounded = false;       // 地面にいるかどうか

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D を取得
    }

    void Update()
    {
        // 指定したキーが押されたとき地面にいたらジャンプできる
        if (Input.GetKeyDown(controlKey) && isGrounded)
        {
            // 上方向にランダムな力の方向を決定
            Vector2 randomDirection = new Vector2(Random.Range(-0.5f, 0.5f), 1f); // 常に上向き
            Vector2 force = randomDirection.normalized * tapForce;

            rb.AddForce(force, ForceMode2D.Impulse); // 瞬間的な力を加える
        }
    }

    // 地面に着地したときに呼ばれる
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 何かに触れたら地面にいると判定（地面タグなどを使ってもOK）
        isGrounded = true;
    }

    // 地面から離れたときに呼ばれる
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}