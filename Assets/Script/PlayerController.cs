using UnityEngine;

// �v���C���[���L�[�������ĂƂ�Ƃ�ł���悤�ɂ���X�N���v�g
public class PlayerController : MonoBehaviour
{
    public KeyCode controlKey = KeyCode.A; // ����L�[�iA�L�[��L�L�[�Ȃǁj
    public float tapForce = 3f;            // �͂̋���

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D���擾
    }

    void Update()
    {
        // �w�肵���L�[�������ꂽ��
        if (Input.GetKeyDown(controlKey))
        {
            // ��������ۂ������_���ȕ����ɗ͂�������
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
            Vector2 force = randomDirection.normalized * tapForce;

            rb.AddForce(force, ForceMode2D.Impulse); // ��u�̗͂�������
        }
    }
}