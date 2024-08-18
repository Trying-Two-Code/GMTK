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
        for (int i = 0; i < Ceiling.Length; i++)
        {
            Ceiling[i].position = Vector3.MoveTowards(Ceiling[i].position, center.position, Time.deltaTime * speed * ceilingMult);
        }

    }

    private void Update()
    {
        Shrink();
    }


    //\/\/\/\/\/\/ RESET OBJECTS POSITIONS \/\/\/\/\/\/
    private void Start()
    {
        SetObjs();
    }

    private struct obj
    {
        public Vector3 position;
        public GameObject _object;
    }
    private obj[] AllThings;

    private void SetObjs()
    {
        int i = 0;
        AllThings = new obj[Walls.Length + Ceiling.Length + props.Length];
        foreach (Transform roomPart in Walls)
        {
            i++;
            AllThings[i]._object = roomPart.gameObject;
            AllThings[i].position = roomPart.position;
        }
        foreach (Transform roomPart in Ceiling)
        {
            i++;
            AllThings[i]._object = roomPart.gameObject;
            AllThings[i].position = roomPart.position;
        }
        foreach (GameObject prop in props)
        {
            i++;
            AllThings[i]._object = prop;
            AllThings[i].position = prop.transform.position;
        }
    }

    void ResetAll()
    {
        foreach(obj THING in AllThings)
        {
            THING._object.transform.position = THING.position;
        }
    }

}
