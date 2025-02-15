using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public Slider progressBar;
    public int maxProgress = 100; 
    private int currentProgress = 0;

    void Start()
    {
        if (progressBar != null)
        {
            progressBar.maxValue = maxProgress;
            progressBar.value = 0;
        }
    }

    public void IncreaseProgress()
    {
        if (currentProgress < maxProgress)
        {
            currentProgress++;
            progressBar.value = currentProgress;

            if (currentProgress >= maxProgress)
            {
                GameOver();
            }
        }
    }

    public void DecreaseProgress()
    {
        if (currentProgress > 0)  // Prevents progress from going below 0
        {
            currentProgress--;
            progressBar.value = currentProgress;
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over! You filled the progress bar.");
    }
}
