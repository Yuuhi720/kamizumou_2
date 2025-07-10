using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���Ǘ��Ɏg��

public class Out : MonoBehaviour
{
    private bool gameEnded = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameEnded) return; 

        if (other.CompareTag("Rikishi1"))
        {
            Debug.Log("Rikishi1����O�IRikishi2�̏����I");
            EndGame("Rikishi2�̏����I");
        }
        else if (other.CompareTag("Rikishi2"))
        {
            Debug.Log("Rikishi2����O�IRikishi1�̏����I");
            EndGame("Rikishi1�̏����I");
        }
    }

    void EndGame(string winnerText)
    {
        gameEnded = true;
       // Time.timeScale = 0f; // �Q�[�����ꎞ��~
        Debug.Log(winnerText + " �Q�[���I���I");
    }
}