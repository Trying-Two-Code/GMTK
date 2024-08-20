using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class passcode : MonoBehaviour, IInteractable
{
    public int code;
    public TextMeshProUGUI text;
    private bool isInteracting;
    public void Interact(PlayerManager player)
    {
        isInteracting = true;
        text.gameObject.SetActive(true);
        text.gameObject.GetComponent<detectNums>()._pascode = this;
    }

}
