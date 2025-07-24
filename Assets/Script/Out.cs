using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理に使う

public class Out : MonoBehaviour
{
    private bool gameEnded = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameEnded) return; 

        if (other.CompareTag("Rikishi1"))
        {
           
            EndGame("Rikishi2の勝ち！");
        }
        else if (other.CompareTag("Rikishi2"))
        {
           
            EndGame("Rikishi1の勝ち！");
        }
    }

    void EndGame(string winnerText)
    {
        gameEnded = true;
        Debug.Log(winnerText + " ゲーム終了！");
    }
}