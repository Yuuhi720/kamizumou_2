using UnityEngine;

public class Out : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rikishi1"))
        {
            Debug.Log("Rikishi1が場外！Rikishi2の勝ち！");

        }
        else if (other.CompareTag("Rikishi2"))
        {
            Debug.Log("Rikishi2が場外！Rikishi1の勝ち！");
        }
    }
}