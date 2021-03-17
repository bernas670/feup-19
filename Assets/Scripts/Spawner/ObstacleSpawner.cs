using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float spawnInterval = 4; //in s
    public float xPos = 10;
    public SpawnableObstacle[] obstacles;
    public LevelGenerator generator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObstacleSpawn());
    }

    IEnumerator ObstacleSpawn()
    {
        while (true)
        {
            int chosenIndex = Random.Range(0, obstacles.Length);
            SpawnableObstacle obstacle = obstacles[chosenIndex];

            InstantiateObstacle(obstacle.prefab, new Vector3(xPos, obstacle.yPos, 0));

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void InstantiateObstacle(GameObject obstaclePrefab, Vector3 position)
    {
        GameObject obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
        obstacle.transform.parent = generator.GetStage(1);
    }
}
