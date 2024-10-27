using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; 
    public GameObject colorChangePrefab; 
    public float spawnInterval = 4f; 
    public float spawnXPosition = 0f; 
    private float currentYPosition;

    private void Start()
    {
        currentYPosition = 10f; 

        for (int i = 0; i < 50; i++)
        {
            SpawnObject();
        }
    }

    private void Update()
    {
        if (Camera.main.transform.position.y + 10 > currentYPosition)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(spawnXPosition, currentYPosition, 0);

        if (currentYPosition >= 10 && currentYPosition % 10 == 0)
        {
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Spawned Obstacle at: " + currentYPosition); 

            Vector3 colorChangePosition = new Vector3(spawnXPosition, currentYPosition + 5f, 0);
            Instantiate(colorChangePrefab, colorChangePosition, Quaternion.identity);
            Debug.Log("Spawned ColorChange at: " + colorChangePosition);
        }

        currentYPosition += spawnInterval; 
    }
}
