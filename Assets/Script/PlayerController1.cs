using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController1 : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.W; // �W�����v�Ɏg���L�[

    public float maxJumpForce = 20f;    // �ő�W�����v��
    private float jumpCharge = 0f;      // ���߂��W�����v��

    private Rigidbody2D rb;
    private bool isGrounded = false;    // �n�ʂɐڂ��Ă��邩�ǂ���

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �n�ʂɂ��āA�W�����v�L�[�𒷉������Ă���Ԃ̓W�����v�͂𗭂߂�
        if (Input.GetKey(jumpKey) && isGrounded)
        {
            jumpCharge += Time.deltaTime * 10f; // ���b10���`���[�W
            jumpCharge = Mathf.Clamp(jumpCharge, 0, maxJumpForce); // �������
        }

        // �W�����v�L�[�𗣂����Ƃ��W�����v��
        if (Input.GetKeyUp(jumpKey) && isGrounded)
        {
            // ���͂��ꂽ�����𒲂ׂ�
            float h = 0f;
            float v = 0f;

            if (Input.GetKey(KeyCode.A)) h = -1f; // ��
            if (Input.GetKey(KeyCode.D)) h = 1f;  // �E
            if (Input.GetKey(KeyCode.W)) v = 1f;  // ��

            Vector2 direction = new Vector2(h, v);

            // ���������͂���Ă��Ȃ��ꍇ�́A�^��ɃW�����v
            if (direction == Vector2.zero)
                direction = Vector2.up;

            // �w������Ɉړ�����
            Vector2 force = direction.normalized * jumpCharge;
            rb.AddForce(force, ForceMode2D.Impulse);

            // ��Ԃ����Z�b�g
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