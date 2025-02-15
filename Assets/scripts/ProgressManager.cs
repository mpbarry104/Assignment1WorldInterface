using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; private set; }

    public Slider progressBar;
    public int maxProgress = 10;
    private int currentProgress = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
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
        if (currentProgress > 0)
        {
            currentProgress--;
            progressBar.value = currentProgress;
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over! Progress bar full.");
    }
}
