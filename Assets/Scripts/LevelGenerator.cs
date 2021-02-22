using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private Transform stage;
    [SerializeField] private float speed = 10f;



    private Transform currentStage, nextStage;

    void Awake()
    {
        // currentStage = stage;
        currentStage = loadStage(stage, new Vector3(0, 0, 0));


        // Vector3 nextSpawn = new Vector3(currentStage.GetChild(0).position.x, 0, 0);



        


        // nextStage = loadStage(stage, nextSpawn);

        // loadStage(currentStage, new Vector3(0, 0, 0));
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        currentStage.Translate(Vector3.left * speed * Time.deltaTime);
    }

    Transform loadStage(Transform stage, Vector3 spawnPosition)
    {
        return Instantiate(stage, spawnPosition, Quaternion.identity);
    }
}
