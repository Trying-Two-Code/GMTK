using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTowards : MonoBehaviour
{
    public float speed = 10f;
    public bool StartGoing;
    public Transform target;
    public GameObject DeathScreen;

    private void Update()
    {
        if (StartGoing)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            if(Vector3.Distance(transform.position, target.position) <= 1f)
            {
                DeathScreen.SetActive(true);
            }
        }
    }
}
