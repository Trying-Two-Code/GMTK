using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingRoom2 : MonoBehaviour
{
    [Header("Room Parts")]
    [SerializeField] private Transform[] Walls;
    [SerializeField] private Transform[] Ceiling;
    public GameObject[] props;
    public Transform center;

    [Header("Variables")]
    public float speed = 1f;
    [SerializeField] private float ceilingMult = 0.5f;
    [SerializeField] private float playerMult = 0.25f;
    [SerializeField] private float wallMult = 1f;

    public void Shrink()
    {
        for (int i = 0; i < Walls.Length; i++)
        {
            Walls[i].position = Vector3.MoveTowards(Walls[i].position, center.position, Time.deltaTime * speed * wallMult);
        }
    }

    private void Update()
    {
        Shrink();
    }

}
