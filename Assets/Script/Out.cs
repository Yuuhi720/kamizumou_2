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
            Debug.Log("Rikishi1が場外！Rikishi2の勝ち！");
            EndGame("Rikishi2の勝ち！");
        }
        else if (other.CompareTag("Rikishi2"))
        {
            Debug.Log("Rikishi2が場外！Rikishi1の勝ち！");
            EndGame("Rikishi1の勝ち！");
        }
    }

    void EndGame(string winnerText)
    {
        gameEnded = true;
       // Time.timeScale = 0f; // ゲームを一時停止
        Debug.Log(winnerText + " ゲーム終了！");
    }
}