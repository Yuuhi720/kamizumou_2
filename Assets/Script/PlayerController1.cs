using UnityEngine;

// Rigidbody2D を必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController1 : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.W; // ジャンプに使うキー

    
    public float maxJumpForce = 20f;    // 最大ジャンプ力
    private float jumpCharge = 0f;      // 溜めたジャンプ力

    public Transform groundCheck;       //足元の位置
    public float groundCheckRadius = 0.2f;//接地判定の半径
    public LayerMask groundLayer;       //レイヤー

    private Rigidbody2D rb;             //Rigidbody2Dへの参照
    private bool isGrounded = false;    //地面に接しているかどうか

    void Start()
    {
        // Rigidbody2D を取得
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //ジャンプキーを離したときジャンプ
        if (Input.GetKey(jumpKey) && isGrounded)
        {
            jumpCharge += Time.deltaTime * 10f; // 毎秒10ずつ
            jumpCharge = Mathf.Clamp(jumpCharge, 0, maxJumpForce); // 上限あり
        }

        //ジャンプ処理
        //ジャンプキーを離したときジャンプ
        if (Input.GetKeyUp(jumpKey) && isGrounded)
        {
            //入力された方向を調べる
            float h = 0f;
            float v = 0f;

            if (Input.GetKey(KeyCode.A)) h = -1f;//左
            if (Input.GetKey(KeyCode.D)) h = 1f;//右
            if (Input.GetKey(KeyCode.W)) v = 1f;//上

            Vector2 direction = new Vector2(h, v);

            //方向が入力されていない場合は、真上にジャンプ
            if (direction == Vector2.zero)
                direction = Vector2.up;

            //指定方向に移動する
            Vector2 force = direction.normalized * jumpCharge;
            rb.AddForce(force, ForceMode2D.Impulse);

            //状態をリセット
            jumpCharge = 0f;
            isGrounded = false;//空中に出たため false に
        }
    }     // ジャンプキーを離したときジャンプ

    //groundCheckの円を表示
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}