using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 2; //in s
    public float xPos = 10; //in s
    public float[] yPos = new float[] { -3.68f, 1.38f }; //in s

    public GameObject enemyPrefab;
    public LevelGenerator generator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            // 0 -> lower level
            // 1 -> Upper Level
            // 2 -> Both
            int spawnLevel = Random.Range(0, yPos.Length);

            if (spawnLevel < yPos.Length)
            {
                InstantiateEnemy(new Vector3(xPos, yPos[spawnLevel], 0));
            }
            else
            {
                InstantiateEnemy(new Vector3(xPos, yPos[0], 0));
                InstantiateEnemy(new Vector3(xPos, yPos[1], 0));
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void InstantiateEnemy(Vector3 pos)
    {
        GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
        enemy.transform.parent = generator.GetStage(1);
    }
}
