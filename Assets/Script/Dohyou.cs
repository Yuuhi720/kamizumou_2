using UnityEngine;


public class Dohyou : MonoBehaviour
{
    // —h‚ê‚é‘å‚«‚³
    public float shakeAmount = 0.1f;

    // —h‚ê‚é‘¬‚³
    public float shakeSpeed = 5f;

    // ‰ŠúˆÊ’u‚ğŠo‚¦‚Æ‚­•Ï”
    Vector3 startPos;

    // —h‚ê‚Ä‚é‚©‚Ç‚¤‚©‚Ì”»’è
    bool shaking = false;

    void Start()
    {

        startPos = transform.position;
    }

    void Update()
    {
        // ƒXƒy[ƒXƒL[‚ğ‰Ÿ‚µ‚½‚Æ‚«—h‚ê‚éor~‚Ü‚é
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shaking = !shaking;  // true—h‚ê‚éAfalse‚È‚ç~‚Ü‚é‚æ‚¤‚É‚·‚é
        }

        if (shaking)
        {
            // X‚ÆY•ûŒü‚É—h‚ç‚·ŒvZ
            float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float offsetY = Mathf.Cos(Time.time * shakeSpeed * 0.7f) * shakeAmount;

            // ŒvZ‚µ‚½—h‚ê‚ğ“y•U‚ÌˆÊ’u‚É‘«‚µ‚Ä“®‚©‚·
            transform.position = startPos + new Vector3(offsetX, offsetY, 0);
        }
        else
        {
            // —h‚ê‚Ä‚È‚¢‚Æ‚«‚ÍŒ³‚ÌêŠ‚É–ß‚·
            transform.position = startPos;
        }
    }
}