using UnityEngine;

// �͎m�𓮂������߂̃X�N���v�g
public class Controller : MonoBehaviour
{
    // �͎m�̈ړ����鑬��
    public float moveSpeed = 5f;

    // �R���|�[�l���g������ꏊ
    Rigidbody2D rb;

    // �ϐ�
    Vector2 movement;

    void Start()
    {
        // �Q�[�����n�܂�����Rigidbody2D�ɓ����
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �L�[�{�[�h�̍��E��A�ED��movement.x�ɓ����
        movement.x = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        // Rigidbody2D���g���ė͎m�𓮂���
        //���������Ƒ������������������ړ�������
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}