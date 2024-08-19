using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INSTRUCTIONS:

//put walls or anything on walls into the Walls list

//put ceiling or anything on ceiling onto Ceiling list

//change speed to be appropriate: .01f is slow and 1 is very fast

//check if player inside, if it starts inside then make shrinking bool = true in the begining
//If you want to make it check for player in begining go ahead I just don't know how lol, just set shrinking to true and you should be good


public class ShrinkingRoom2 : MonoBehaviour
{
    [Header("Room Parts")]
    [SerializeField] private Transform[] Walls;
    [SerializeField] private Transform[] Ceiling;
    public GameObject[] props;
    public Transform center;

    [Header("Variables")]
    public float speed = .1f;
    [SerializeField] private float ceilingMult = 0.5f;
    [SerializeField] private float playerMult = 0.25f;
    [SerializeField] private float wallMult = 1f;
    [SerializeField] private bool shrinking = false;

    public void Shrink()
    {
        for (int i = 0; i < Walls.Length; i++)
        {
            Walls[i].position = new Vector3(Vector3.MoveTowards(Walls[i].position, center.position, Time.deltaTime * speed * wallMult).x, Walls[i].position.y, Vector3.MoveTowards(Walls[i].position, center.position, Time.deltaTime * speed * wallMult).z);
        }
        for (int i = 0; i < Ceiling.Length; i++)
        {
            Ceiling[i].position = Vector3.MoveTowards(Ceiling[i].position, center.position, Time.deltaTime * speed * ceilingMult);
        }
        for (int i = 0; i < props.Length; i++)
        {
            props[i].transform.position = Vector3.MoveTowards(props[i].transform.position, center.position, Time.deltaTime * speed * ceilingMult / 10f);
        }
    }

    private void Update()
    {
        if (shrinking)
        {
            Shrink();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Debug.Log("START SHRINKING");
            shrinking = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Debug.Log("STOP SHRINKING");
            shrinking = false;
            ResetAll();
        }
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
            
            AllThings[i]._object = roomPart.gameObject;
            AllThings[i].position = roomPart.position;
            i++;
        }
        foreach (Transform roomPart in Ceiling)
        {
            
            AllThings[i]._object = roomPart.gameObject;
            AllThings[i].position = roomPart.position;
            i++;
        }
        foreach (GameObject prop in props)
        {
            
            AllThings[i]._object = prop;
            AllThings[i].position = prop.transform.position;
            i++;
        }
    }

    //call this to set all objects back to their original state
    void ResetAll()
    {
        foreach(obj THING in AllThings)
        {
            THING._object.transform.position = THING.position;
        }
        Destroy(gameObject);
    }

    

}
