using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2 : MonoBehaviour
{
    public KeyCode controlKey = KeyCode.L; // ����L�[�iA�L�[��L�L�[�Ȃǁj
    public float tapForce = 3f;            // �W�����v���ɉ�����͂̑傫��

    private Rigidbody2D rb;
    private bool isGrounded = false;       // �n�ʂɂ��邩�ǂ���

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ���擾
    }

    void Update()
    {
        // �w�肵���L�[�������ꂽ�Ƃ��n�ʂɂ�����W�����v�ł���
        if (Input.GetKeyDown(controlKey) && isGrounded)
        {
            // ������Ƀ����_���ȗ͂̕���������
            Vector2 randomDirection = new Vector2(Random.Range(-0.5f, 0.5f), 1f); // ��ɏ����
            Vector2 force = randomDirection.normalized * tapForce;

            rb.AddForce(force, ForceMode2D.Impulse); // �u�ԓI�ȗ͂�������
        }
    }

    // �n�ʂɒ��n�����Ƃ��ɌĂ΂��
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �����ɐG�ꂽ��n�ʂɂ���Ɣ���i�n�ʃ^�O�Ȃǂ��g���Ă�OK�j
        isGrounded = true;
    }

    // �n�ʂ��痣�ꂽ�Ƃ��ɌĂ΂��
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}