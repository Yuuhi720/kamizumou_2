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
           
            EndGame("Rikishi2�̏����I");
        }
        else if (other.CompareTag("Rikishi2"))
        {
           
            EndGame("Rikishi1�̏����I");
        }
    }

    void EndGame(string winnerText)
    {
        gameEnded = true;
        Debug.Log(winnerText + " �Q�[���I���I");
    }
}