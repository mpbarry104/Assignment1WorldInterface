using UnityEngine;

public class RhythmScoring : MonoBehaviour
{
    private int score = 0;

    public void AddScore(bool isCorrect)
    {
        if (isCorrect)
        {
            score += 10;
            Debug.Log("Score: " + score);
        }
        else
        {
            score -= 5;
            Debug.Log("Score: " + score);
        }
    }
}
