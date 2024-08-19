using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IInteractable
{
    public MeshRenderer _button;
    public Material Deactivated;
    public Material Activated;

    public static int ButtonsPressed = 0;

    public float TimeTilNotPressed = 5f;
    private float t;

    private bool pressed = false;

    public GameObject MoveThis;
    public Transform Here;
    public Door OpenThis;
    public int whenThisManyPressed;
    public void Interact(PlayerManager player)
    {
        _button.material = Activated;
        ButtonsPressed += 1;
        t = TimeTilNotPressed;
        pressed = true;
    }

    private void Update()
    {

        if (pressed)
        {
            Debug.Log(ButtonsPressed);
            t -= Time.deltaTime;
            if(t <= 0)
            {
                DeactivateButton();
            }
            if(OpenThis != null)
            {
                if (ButtonsPressed >= whenThisManyPressed)
                {
                    OpenThis.Open();
                }
            }
            if(MoveThis != null)
            {
                if (ButtonsPressed >= whenThisManyPressed)
                {
                    MoveThis.transform.position = Here.position;
                    MoveThis = null;
                }
            }
            
        }
    }

    void DeactivateButton()
    {
        pressed = false;
        t = TimeTilNotPressed;
        ButtonsPressed -= 1;
        _button.material = Deactivated;
    }

}
