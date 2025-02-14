using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject[] arrowPrefabs;  // Array to hold arrow prefabs
    public GameObject spawnPoint;      // Reference to the empty GameObject (spawn point)
    public GameObject targetZone;     // Reference to the empty GameObject (target zone)
    public float spawnInterval = 1f;   // Interval between arrow spawns
    public float speed = 5f;           // Speed at which arrows move down
    private float timeToNextSpawn;

    void Start()
    {
        timeToNextSpawn = spawnInterval;
    }

    void Update()
    {
        timeToNextSpawn -= Time.deltaTime;

        if (timeToNextSpawn <= 0)
        {
            if (arrowPrefabs != null && arrowPrefabs.Length > 0)
            {
                int randomArrow = Random.Range(0, arrowPrefabs.Length);

                // Ensure spawnPoint and targetZone are assigned
                if (spawnPoint != null && targetZone != null)
                {
                    // Instantiate the arrow at the spawn point's position
                    GameObject arrow = Instantiate(arrowPrefabs[randomArrow], spawnPoint.transform.position, Quaternion.identity);

                    // Ensure the Arrow script is attached to the prefab
                    Arrow arrowScript = arrow.GetComponent<Arrow>();
                    if (arrowScript != null)
                    {
                        // Initialize the arrow with speed and the position of the target zone
                        arrowScript.Initialize(speed, targetZone.transform.position.y);
                    }
                    else
                    {
                        Debug.LogError("Arrow script not found on prefab!");
                    }
                }
                else
                {
                    Debug.LogError("Spawn point or target zone is not assigned!");
                }

                timeToNextSpawn = spawnInterval;
            }
            else
            {
                Debug.LogError("Arrow prefabs are not assigned!");
            }
        }
    }
}
