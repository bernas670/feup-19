using UnityEngine;

public class LinearVirus : Virus
{

    public Vector3[] spots;
    private int nextSpot = 1;


    void Start()
    {
        transform.position = spots[nextSpot];
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, spots[nextSpot], speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, spots[nextSpot]) <= 0.1) {
            nextSpot++;

            if (nextSpot >= spots.Length) {
                nextSpot = 0;
            }
        }
    }
}
