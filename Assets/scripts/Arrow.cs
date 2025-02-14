using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    private float targetZoneY;
    private bool isInTargetZone = false;
    private bool isPressed = false;
    private float targetZoneThreshold = 0.1f;

    public void Initialize(float arrowSpeed, float targetY)
    {
        speed = arrowSpeed;
        targetZoneY = targetY;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.y - targetZoneY) <= targetZoneThreshold)
        {
            isInTargetZone = true;
        }

        if (isInTargetZone && !isPressed)
        {
            if (Input.GetKeyDown(KeyCode.W) && tag == "Up")
            {
                HandleHit(true);
            }
            else if (Input.GetKeyDown(KeyCode.S) && tag == "Down")
            {
                HandleHit(true);
            }
            else if (Input.GetKeyDown(KeyCode.A) && tag == "Left")
            {
                HandleHit(true);
            }
            else if (Input.GetKeyDown(KeyCode.D) && tag == "Right")
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
            ScoreManager.Instance.AddScore(100);
        }
        else
        {
            Debug.Log("Missed!");
            ScoreManager.Instance.AddScore(-50);
        }

        isPressed = true;
        Destroy(gameObject);
    }
}
