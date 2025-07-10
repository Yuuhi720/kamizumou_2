using UnityEngine;

public class Controller : MonoBehaviour
{
    // 押す力の強さ
    public float pushPower = 10f;

    // trueならプレイヤー1（A/Dキー操作）、falseならプレイヤー2（←/→キー操作）
    public bool Rikishi1 = true;

    Rigidbody2D rb;
    Vector2 movement;  // 移動方向を表すベクトル（x軸のみ使用）

    void Start()
    {
        // Rigidbody2Dを取得して変数に代入
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 毎フレーム、movementをリセット（停止状態を意味する）
        movement = Vector2.zero;

        if (Rikishi1)
        {
            // プレイヤー1の入力判定（AキーとDキー）
            bool isAPressed = Input.GetKey(KeyCode.A);
            bool isDPressed = Input.GetKey(KeyCode.D);

            if (isAPressed && !isDPressed)
            {
                movement.x = -1;  // 左方向へ移動
            }
            else if (!isAPressed && isDPressed)
            {
                movement.x = 1;   // 右方向へ移動
            }
            else
            {
                movement.x = 0;   // 停止
            }
        }
        else
        {
            // プレイヤー2の入力判定（左矢印キーと右矢印キー）
            bool isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
            bool isRightPressed = Input.GetKey(KeyCode.RightArrow);

            if (isLeftPressed && !isRightPressed)
            {
                movement.x = -1;  // 左方向へ移動
            }
            else if (!isLeftPressed && isRightPressed)
            {
                movement.x = 1;   // 右方向へ移動
            }
            else
            {
                movement.x = 0;   // 停止
            }
        }
    }

    void FixedUpdate()
    {
        // Rigidbody2Dに力を加えて押し合いの動きを実現
        rb.AddForce(movement * pushPower);
    }

}