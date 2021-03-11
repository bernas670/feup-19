using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float spawnInterval = 4; //in s
    public float xPos = 10;
    public float[] yPos;

    public GameObject[] obstaclePrefabs;
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
            //FIXME: the chosen index selects both the yPos and the Prefab. Any idea to couple both?
            int chosenIndex = Random.Range(0, obstaclePrefabs.Length);

            //TODO: if index == Length then Generate Nothing??
            InstantiateObstacle(obstaclePrefabs[chosenIndex],new Vector3(xPos, yPos[chosenIndex], 0));

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void InstantiateObstacle(GameObject obstaclePrefab, Vector3 position)
    {
        GameObject obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
        obstacle.transform.parent = generator.GetStage(1);
    }
}
