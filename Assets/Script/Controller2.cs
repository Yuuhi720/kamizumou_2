using UnityEngine;

// �͎m�𓮂������߂̃X�N���v�g
public class Controller2 : MonoBehaviour
{
    // �͎m�̈ړ����鑬��
    public float moveSpeed = 5f;

    // �R���|�[�l���g������ꏊ
    Rigidbody2D rb;

    // �ϐ�
    Vector2 movement;

    void Start()
    {
        // �Q�[�����n�܂�����Rigidbody�ɓ����
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      
        movement.y = Input.GetAxisRaw("vertical");

    }

    void FixedUpdate()
    {
        // Rigidbody2D���g���ė͎m�𓮂���
        //���������Ƒ������������������ړ�������
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}