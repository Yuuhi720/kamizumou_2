using UnityEngine;

// プレイヤーがキーを押してとんとんできるようにするスクリプト
public class PlayerController : MonoBehaviour
{
    public KeyCode controlKey = KeyCode.A; // 操作キー（AキーやLキーなど）
    public float tapForce = 3f;            // 力の強さ

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dを取得
    }

    void Update()
    {
        // 指定したキーが押されたら
        if (Input.GetKeyDown(controlKey))
        {
            // 上方向っぽいランダムな方向に力を加える
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
            Vector2 force = randomDirection.normalized * tapForce;

            rb.AddForce(force, ForceMode2D.Impulse); // 一瞬の力を加える
        }
    }
}