//using UnityEngine;


//public class Dohyou : MonoBehaviour
//{
//    // �h���傫��
//    public float shakeAmount = 0.1f;

//    // �h��鑬��
//    public float shakeSpeed = 5f;

//    // �����ʒu
//    Vector3 startPos;

//    // �h��Ă邩�ǂ����̔���
//    bool shaking = false;

//    void Start()
//    {

//        startPos = transform.position;
//    }

//    void Update()
//    {
//        // �X�y�[�X�L�[���������Ƃ��h��邩�~�܂�
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            shaking = !shaking;  // true�Ȃ�h���Afalse�Ȃ�~�܂�悤�ɂ���
//        }

//        if (shaking)
//        {
//            // X��Y�����ɗh�炷�v�Z
//            float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
//            float offsetY = Mathf.Cos(Time.time * shakeSpeed * 0.7f) * shakeAmount;

//            // �v�Z�����h���y�U�̈ʒu�ɑ����ē�����
//            transform.position = startPos + new Vector3(offsetX, offsetY, 0);
//        }
//        else
//        {
//            // �h��ĂȂ��Ƃ��͏����ʒu�ɖ߂�
//            transform.position = startPos;
//        }
//    }
//}