using UnityEngine;


public class Dohyou : MonoBehaviour
{
    // 揺れる大きさ
    public float shakeAmount = 0.1f;

    // 揺れる速さ
    public float shakeSpeed = 5f;

    // 初期位置
    Vector3 startPos;

    // 揺れてるかどうかの判定
    bool shaking = false;

    void Start()
    {

        startPos = transform.position;
    }

    void Update()
    {
        // スペースキーを押したとき揺れるか止まる
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shaking = !shaking;  // trueなら揺れる、falseなら止まるようにする
        }

        if (shaking)
        {
            // XとY方向に揺らす計算
            float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float offsetY = Mathf.Cos(Time.time * shakeSpeed * 0.7f) * shakeAmount;

            // 計算した揺れを土俵の位置に足して動かす
            transform.position = startPos + new Vector3(offsetX, offsetY, 0);
        }
        else
        {
            // 揺れてないときは初期位置に戻す
            transform.position = startPos;
        }
    }
}