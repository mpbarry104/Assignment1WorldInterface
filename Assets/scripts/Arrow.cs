using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    private float targetZoneY;
    private bool isInTargetZone = false;
    private bool isPressed = false;

    public void Initialize(float arrowSpeed, float targetY)
    {
        speed = arrowSpeed;
        targetZoneY = targetY;
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y >= targetZoneY && !isInTargetZone)
        {
            isInTargetZone = true;
        }

        if (isInTargetZone && !isPressed)
        {
            if (Input.GetKeyDown(KeyCode.W) && tag == "Up" ||
                Input.GetKeyDown(KeyCode.S) && tag == "Down" ||
                Input.GetKeyDown(KeyCode.A) && tag == "Left" ||
                Input.GetKeyDown(KeyCode.D) && tag == "Right")
            {
                HandleHit(true);
            }
            else if (Input.anyKeyDown)
            {
                HandleHit(false);
            }
        }
    }

    void HandleHit(bool isCorrect)
    {
        if (isCorrect)
        {
            Debug.Log("Perfect Hit!");
            ProgressManager.Instance.IncreaseProgress();
        }
        else
        {
            Debug.Log("Missed!");
            
            ProgressManager.Instance.DecreaseProgress();
        }

        isPressed = true;
        Destroy(gameObject);
    }
}
