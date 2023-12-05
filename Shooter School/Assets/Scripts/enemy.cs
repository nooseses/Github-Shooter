using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    public NavMeshAgent badGuy;
    public float squareOfMovement = 20f;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    private float xPos;
    private float yPos;
    private float zPos;

    public float closeEnough = 2f;

    // Start is called before the first frame update
    void Start()
    {
        xMin = zMin = squareOfMovement;
        zMax = zMax = squareOfMovement;
        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPos, yPos, zPos)) <= closeEnough)
        {
            newLocation();
        }
    }

    public void newLocation()
    {
        xPos = Random.Range(xMin, xMax);
        yPos = transform.position.y;
        zPos = Random.Range(zMin, zMax);

        badGuy.SetDestination(new Vector3(xPos, yPos, zPos));
    }
}

