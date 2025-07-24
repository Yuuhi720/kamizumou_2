using UnityEngine;

public class Controller : MonoBehaviour
{
    //押す力の強さ
    public float pushPower = 10f;

    // プレイヤー1（A/Dキー操作）プレイヤー2（←/→キー操作）
    public bool Rikishi1 = true;

    Rigidbody2D rb;
    Vector2 movement;  //移動方向

    void Start()
    {
        // Rigidbody2Dを取得して変数に代入
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //停止
        movement = Vector2.zero;

        if (Rikishi1)
        {
            // プレイヤー1入力判定（AキーとDキー）
            bool isAPressed = Input.GetKey(KeyCode.A);
            bool isDPressed = Input.GetKey(KeyCode.D);

            if (isAPressed && !isDPressed)
            {
                movement.x = -1;  //左方向へ移動
            }
            else if (!isAPressed && isDPressed)
            {
                movement.x = 1;   //右方向へ移動
            }
            else
            {
                movement.x = 0;   //停止
            }
        }
        else
        {
            // プレイヤー2入力判定（左矢印キーと右矢印キー）
            bool isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
            bool isRightPressed = Input.GetKey(KeyCode.RightArrow);

            if (isLeftPressed && !isRightPressed)
            {
                movement.x = -1;  //左方向へ移動
            }
            else if (!isLeftPressed && isRightPressed)
            {
                movement.x = 1;   //右方向へ移動
            }
            else
            {
                movement.x = 0;   //停止
            }
        }
    }

    

}