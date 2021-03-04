using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] public GameObject stage;
    [SerializeField] public GameObject startingStage;
    [SerializeField] public float speed = 10f;

    private GameObject firstStage, secondStage, thirdStage;
    private Transform firstTransform, secondTransform, thirdTransform;
    private float stageWidth = 20f; // Not the actual width, but works well

    void Awake()
    {
        firstStage = startingStage;
        firstTransform = startingStage.GetComponent<Transform>();

        secondStage = loadStage(stage, getSpawnPositionFrom(firstTransform));
        secondTransform = secondStage.GetComponent<Transform>();

        thirdStage = loadStage(stage, getSpawnPositionFrom(secondTransform));
        thirdTransform = thirdStage.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        firstTransform.Translate(Vector3.left * speed * Time.deltaTime);
        secondTransform.Translate(Vector3.left * speed * Time.deltaTime);
        thirdTransform.Translate(Vector3.left * speed * Time.deltaTime);

        // When the first stage leaves the screen (with a small offset)
        // it is deleted.Remaining stages are shifted to the left and a
        // new thirdStage is instantiated
        if (firstTransform.Find("EndPosition").position.x < (-stageWidth / 2))
        {
            Destroy(firstStage);
            // Debug.Log("Stage Destroyed!");

            firstStage = secondStage;
            firstTransform = secondTransform;

            secondStage = thirdStage;
            secondTransform = thirdTransform;

            thirdStage = loadStage(stage, getSpawnPositionFrom(secondTransform));
            thirdTransform = thirdStage.GetComponent<Transform>();
        }
    }

    GameObject loadStage(GameObject prefab, Vector3 spawnPosition)
    {
        return Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    Vector3 getSpawnPositionFrom(Transform transf)
    {
        return transf.Find("EndPosition").position + new Vector3(stageWidth / 2, 0, 0);
    }

    public Transform GetCurrentStage()
    {
        return firstTransform;
    }
}
