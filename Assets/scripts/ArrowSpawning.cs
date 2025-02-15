using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject[] arrowPrefabs;
    public float spawnInterval = 1f;
    public float speed = 5f;

    public Transform spawnPoint; // Empty GameObject for arrow spawning
    public Transform targetZone; // Empty GameObject for the target area

    private float timeToNextSpawn;

    private Dictionary<string, float> spawnPositions = new Dictionary<string, float>()
    {
        { "Left", -3f },   // X position for Left arrows
        { "Down", -1f },   // X position for Down arrows
        { "Up", 1f },      // X position for Up arrows
        { "Right", 3f }    // X position for Right arrows
    };

    void Start()
    {
        timeToNextSpawn = spawnInterval;
    }

    void Update()
    {
        timeToNextSpawn -= Time.deltaTime;

        if (timeToNextSpawn <= 0)
        {
            SpawnArrow();
            timeToNextSpawn = spawnInterval;
        }
    }

    void SpawnArrow()
    {
        int randomIndex = Random.Range(0, arrowPrefabs.Length);
        GameObject arrowPrefab = arrowPrefabs[randomIndex];

        string arrowTag = arrowPrefab.tag;
        float spawnX = spawnPositions.ContainsKey(arrowTag) ? spawnPositions[arrowTag] : 0f;

        // Spawn position from the empty GameObject
        Vector3 spawnPosition = new Vector3(spawnX, spawnPoint.position.y, 0);
        GameObject arrow = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);

        // Assign speed and target zone position based on empty GameObject
        arrow.GetComponent<Arrow>().Initialize(speed, targetZone.position.y);
    }
}
