//using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
//public class PlayerController2 : MonoBehaviour
//{
//    public KeyCode jumpKey = KeyCode.L; // �W�����v�p�̃L�[

//    public float maxJumpForce = 20f; // �ő�W�����v��
//    private float jumpCharge = 0f;   // ���߂��W�����v��

//    private Rigidbody2D rb;

//    public Transform groundCheck;
//    public float groundCheckRadius = 0.1f;
//    public LayerMask groundLayer;
//    private bool isGrounded = false;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        //�n�ʂɐG��Ă��邩�ǂ������ׂ�
//        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

//        //�W�����v�͂𗭂߂�
//        if (Input.GetKey(jumpKey) && isGrounded)
//        {
//            jumpCharge += Time.deltaTime * 10f;
//            jumpCharge = Mathf.Clamp(jumpCharge, 0f, maxJumpForce);
//        }

//        //�ړ�������������߂�
//        if (Input.GetKeyUp(jumpKey) && isGrounded)
//        {
//            float h = 0f;
//            float v = 0f;

//            if (Input.GetKey(KeyCode.LeftArrow)) h = -1f;
//            if (Input.GetKey(KeyCode.RightArrow)) h = 1f;
//            if (Input.GetKey(KeyCode.UpArrow)) v = 1f;


//            Vector2 direction = new Vector2(h, v);
//            if (direction == Vector2.zero)
//                direction = Vector2.up;

//            Vector2 force = direction.normalized * jumpCharge;
//            rb.AddForce(force, ForceMode2D.Impulse);

//            jumpCharge = 0f;
//        }
//    }

//}