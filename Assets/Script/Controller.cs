using UnityEngine;

public class Controller : MonoBehaviour
{
    //�����͂̋���
    public float pushPower = 10f;

    // �v���C���[1�iA/D�L�[����j�v���C���[2�i��/���L�[����j
    public bool Rikishi1 = true;

    Rigidbody2D rb;
    Vector2 movement;  //�ړ�����

    void Start()
    {
        // Rigidbody2D���擾���ĕϐ��ɑ��
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //��~
        movement = Vector2.zero;

        if (Rikishi1)
        {
            // �v���C���[1���͔���iA�L�[��D�L�[�j
            bool isAPressed = Input.GetKey(KeyCode.A);
            bool isDPressed = Input.GetKey(KeyCode.D);

            if (isAPressed && !isDPressed)
            {
                movement.x = -1;  //�������ֈړ�
            }
            else if (!isAPressed && isDPressed)
            {
                movement.x = 1;   //�E�����ֈړ�
            }
            else
            {
                movement.x = 0;   //��~
            }
        }
        else
        {
            // �v���C���[2���͔���i�����L�[�ƉE���L�[�j
            bool isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
            bool isRightPressed = Input.GetKey(KeyCode.RightArrow);

            if (isLeftPressed && !isRightPressed)
            {
                movement.x = -1;  //�������ֈړ�
            }
            else if (!isLeftPressed && isRightPressed)
            {
                movement.x = 1;   //�E�����ֈړ�
            }
            else
            {
                movement.x = 0;   //��~
            }
        }
    }

    

}