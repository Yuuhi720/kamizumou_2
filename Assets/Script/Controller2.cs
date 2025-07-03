using UnityEngine;

// 力士を動かすためのスクリプト
public class Controller2 : MonoBehaviour
{
    // 力士の移動する速さ
    public float moveSpeed = 5f;

    // コンポーネントを入れる場所
    Rigidbody2D rb;

    // 変数
    Vector2 movement;

    void Start()
    {
        // ゲームが始まったらRigidbody2Dに入れる
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // キーボードの左右とA・Dをmovement.xに入れる
        movement.y = Input.GetAxisRaw("vertical");

    }

    void FixedUpdate()
    {
        // Rigidbody2Dを使って力士を動かす
        //動く方向と速さをかけた分だけ移動させる
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}