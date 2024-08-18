using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingRoom : MonoBehaviour
{
    [SerializeField] private float shrinkSpeed = 0.1f;
    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    [SerializeField] private Transform backWall;
    [SerializeField] private Transform frontWall;
    [SerializeField] private Transform ceiling;

    private void FixedUpdate()
    {
        leftWall.transform.position -= new Vector3(shrinkSpeed, 0, 0);
        rightWall.transform.position += new Vector3(shrinkSpeed, 0, 0);
        backWall.transform.position -= new Vector3(0, 0, shrinkSpeed);
        frontWall.transform.position += new Vector3(0, 0, shrinkSpeed);
        ceiling.transform.position -= new Vector3(0, shrinkSpeed, 0);
    }
}
