using UnityEngine;

public class Out : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rikishi1"))
        {
            Debug.Log("Rikishi1����O�IRikishi2�̏����I");

        }
        else if (other.CompareTag("Rikishi2"))
        {
            Debug.Log("Rikishi2����O�IRikishi1�̏����I");
        }
    }
}