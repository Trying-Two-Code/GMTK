using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoTowards : MonoBehaviour
{
    public GoTowards gt = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gt.StartGoing = true;
        }
    }
}
