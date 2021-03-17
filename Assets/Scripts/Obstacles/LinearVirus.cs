using UnityEngine;

public class LinearVirus : Virus
{
    private Transform[] spots;
    private Rigidbody2D rb;
    private int currentSpot = 0;
    private int nextSpot = 1;

    void Start()
    {
        Transform[] tempSpots = transform.GetChild(1).GetComponentsInChildren<Transform>();
        int counter = 0;
        spots = new Transform[tempSpots.Length - 1];

        // Select only the transforms of the children
        foreach (var spot in tempSpots)
        {
            if (spot.gameObject.name.CompareTo("Path") == 0)
                continue;

            spots.SetValue(spot, counter);
            counter++;
        }

        //Randomly select a starting point to make it harder to predict
        // currentSpot = Random.Range(0, spots.Length);
        // nextSpot = (currentSpot + 1) % spots.Length;

        rb = transform.GetComponentInChildren<Rigidbody2D>();
        rb.position = spots[currentSpot].position;
        this.SetVelocity();
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(rb.position, spots[nextSpot].position) <= 0.3f)
        {
            this.UpdateSpots();
            this.SetVelocity();
        }
    }

    private void SetVelocity()
    {
        Vector3 dir = (spots[nextSpot].position - new Vector3(rb.position.x, rb.position.y, 0)).normalized;
        rb.velocity = dir * speed;
    }

    private void UpdateSpots()
    {
        // Works if cyclic (1->2->3->1->2->3->1 ...)
        currentSpot = (currentSpot + 1) % spots.Length;
        nextSpot = (nextSpot + 1) % spots.Length;
    }
}
