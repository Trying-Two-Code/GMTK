using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFantom : MonoBehaviour
{
    [SerializeField] private LineRenderer path;
    private int pathIndex = 0;
    private int pathLength;
    public float speed;
    public float distTilChange = 1f;

    private void Start()
    {
        pathLength = path.positionCount;
    }

    private void Update()
    {
        MoveAlongPath();
    }

    public void MoveAlongPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.GetPosition(pathIndex), Time.deltaTime * speed);


        if(Vector3.Distance(transform.position, path.GetPosition(pathIndex)) <= distTilChange)
        {
            SetIndex();
        }
    }

    public void SetIndex()
    {
        pathIndex += 1;
        if(pathIndex >= pathLength)
        {
            pathIndex = 0;
        }
    }
}
