using UnityEngine;

// Rigidbody2D ��K�{�ɂ���
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController1 : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.W; // �W�����v�Ɏg���L�[

    
    public float maxJumpForce = 20f;    // �ő�W�����v��
    private float jumpCharge = 0f;      // ���߂��W�����v��

    public Transform groundCheck;       //�����̈ʒu
    public float groundCheckRadius = 0.2f;//�ڒn����̔��a
    public LayerMask groundLayer;       //���C���[

    private Rigidbody2D rb;             //Rigidbody2D�ւ̎Q��
    private bool isGrounded = false;    //�n�ʂɐڂ��Ă��邩�ǂ���

    void Start()
    {
        // Rigidbody2D ���擾
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //�W�����v�L�[�𗣂����Ƃ��W�����v
        if (Input.GetKey(jumpKey) && isGrounded)
        {
            jumpCharge += Time.deltaTime * 10f; // ���b10����
            jumpCharge = Mathf.Clamp(jumpCharge, 0, maxJumpForce); // �������
        }

        //�W�����v����
        //�W�����v�L�[�𗣂����Ƃ��W�����v
        if (Input.GetKeyUp(jumpKey) && isGrounded)
        {
            //���͂��ꂽ�����𒲂ׂ�
            float h = 0f;
            float v = 0f;

            if (Input.GetKey(KeyCode.A)) h = -1f;//��
            if (Input.GetKey(KeyCode.D)) h = 1f;//�E
            if (Input.GetKey(KeyCode.W)) v = 1f;//��

            Vector2 direction = new Vector2(h, v);

            //���������͂���Ă��Ȃ��ꍇ�́A�^��ɃW�����v
            if (direction == Vector2.zero)
                direction = Vector2.up;

            //�w������Ɉړ�����
            Vector2 force = direction.normalized * jumpCharge;
            rb.AddForce(force, ForceMode2D.Impulse);

            //��Ԃ����Z�b�g
            jumpCharge = 0f;
            isGrounded = false;//�󒆂ɏo������ false ��
        }
    }     // �W�����v�L�[�𗣂����Ƃ��W�����v

    //groundCheck�̉~��\��
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}