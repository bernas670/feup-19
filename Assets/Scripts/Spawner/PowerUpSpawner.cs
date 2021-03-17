using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float spawnInterval = 4; //in s
    public float xPos = 9;
    public float yPos = -1.5f;

    public GameObject[] powerUpPrefabs;
    public LevelGenerator generator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PowerUpSpawn());
    }

    IEnumerator PowerUpSpawn()
    {
        while (true)
        {
            int chosenIndex = Random.Range(0, powerUpPrefabs.Length);

            //TODO: if index == Length then Generate Nothing??
            InstantiatePowerUp(powerUpPrefabs[chosenIndex]);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void InstantiatePowerUp(GameObject powerUpPrefab)
    {
        GameObject powerUp = Instantiate(powerUpPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
        powerUp.transform.parent = generator.GetStage(1);
    }
}
